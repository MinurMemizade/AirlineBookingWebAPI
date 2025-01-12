using AirlineBookingWebApi.Exceptions;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Identity;
using AirlineBookingWebApi.Services.Interfaces;
using Azure.Core;
using FluentEmail.Core;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IFluentEmail _fluentEmail;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AuthService(IEmailService emailService, ITokenService tokenService, IConfiguration configuration, RoleManager<Role> roleManager, UserManager<AppUser> userManager, IFluentEmail fluentEmail)
        {
            _emailService = emailService;
            _tokenService = tokenService;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _fluentEmail = fluentEmail;
        }

        public async Task<ResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var oldUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (oldUser == null) throw new Exception("Email or Password is incorrect.");

            if (!await _userManager.CheckPasswordAsync(oldUser, loginDTO.Password)) throw new Exception("Email or Password is incorrect.");


            var userRole = await _userManager.GetRolesAsync(oldUser);
            var jwtToken = await _tokenService.CreateToken(oldUser, userRole);
            string refreshToken = _tokenService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            oldUser.RefreshToken = refreshToken;
            oldUser.RefreshTokenExpireTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(oldUser);
            await _userManager.UpdateSecurityStampAsync(oldUser);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwtToken);

            await _userManager.SetAuthenticationTokenAsync(oldUser, "Default", "AccessToken", tokenString);


            return new ResponseDTO
            {
                StatusCode = 200,
                JWTToken = tokenString,
                RefreshToken = refreshToken,
                Expiration = jwtToken.ValidTo
            };

        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var isExist= await _userManager.FindByEmailAsync(registerDTO.Email);
            if (isExist != null) throw new UserAlreadyExistsException();

            var newUser = new AppUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
            };

            IdentityResult result=await _userManager.CreateAsync(newUser,registerDTO.Password);

            if (result.Succeeded)
            {
                if(await _roleManager.RoleExistsAsync("admin"))
                {
                    await _roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                    await _userManager.AddToRoleAsync(newUser, "admin");
                }

               await _emailService.SendVerificationEmail(newUser.Email);
            }
        }

        public async Task ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user=await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);
            if(user == null) throw new UserNotFoundException();

            var token=await _userManager.GeneratePasswordResetTokenAsync(user);

            var result=await _fluentEmail
            .To(user.Email)
            .Subject("Reset password")
            .Body("Your reset password token: "+token)
            .SendAsync();

            if (!result.Successful) throw new Exception("Unable to send mail.");
        }

        public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user=await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if(user == null) throw new UserNotFoundException();

            await _userManager.ResetPasswordAsync(user,resetPasswordDTO.ResetPasswordToken,resetPasswordDTO.Password);
        }

        public async Task<bool> VerifyEmail(VerificationDTO verificationDTO)
        {
            if (verificationDTO.Email == null || verificationDTO.VerificationToken == null) throw new Exception("Error");
            var user = await _userManager.FindByEmailAsync(verificationDTO.Email);
            if (user == null) throw new UserNotFoundException();
            var result = await _userManager.ConfirmEmailAsync(user, verificationDTO.VerificationToken);
            return result.Succeeded;
        }

        public async Task Revoke(RevokeDTO revokeDTO)
        {
            var user=await _userManager.FindByEmailAsync(revokeDTO.Email);
            if (user == null) throw new UserNotFoundException();

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        public async Task RevokeAll()
        {
            var users=await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
