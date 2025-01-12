using AirlineBookingWebApi.Exceptions;
using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Models.Identity;
using AirlineBookingWebApi.Services.Interfaces;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingWebApi.Services.Implementations
{
    public class EmailService:IEmailService
    {
        private readonly IFluentEmail _fluenEmail;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly LinkGenerator _linkGenerator;

        public EmailService(LinkGenerator linkGenerator, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IFluentEmail fluenEmail, IConfiguration configuration)
        {
            _linkGenerator = linkGenerator;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _fluenEmail = fluenEmail;
            _configuration = configuration;
        }


        public async Task SendVerificationEmail(string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            if (user == null) throw new UserNotFoundException();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            /*var baseUrl = _configuration["AppSettings:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("Base URL is not configured.");

            var confirmationLink= $"{baseUrl}/auth/confirmemail?userId={user.Id}&token={Uri.EscapeDataString(await token)}";
            var emailBody = $@"
        <html>
        <body>
            <h1>Hello,</h1>
            <p>Thank you for registering with us! To complete your registration, please confirm your email address by clicking the link below:</p>
            <p><a href='{confirmationLink}' target='_blank'>Verify Email</a></p>
            <p>If you didn’t register, you can safely ignore this email.</p>
            <p>Thanks,</p>
            <p>The Airline Booking Team</p>
        </body>
        </html>";

            if (confirmationLink == null) throw new Exception("Unable to generate a link.");*/


            var emailResult = await _fluenEmail
                .To(email)
                .Subject("Confirm Email")
                .Body("Your email confirmation token: "+token)
                .SendAsync();

            if(!emailResult.Successful) throw new Exception("Failed to send email.");
        }
    }
}
