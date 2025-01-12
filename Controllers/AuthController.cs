using AirlineBookingWebApi.Models.DTOs;
using AirlineBookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            await _authService.RegisterAsync(registerDTO);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
        {
            return Ok(await _authService.LoginAsync(loginDTO));
        }

        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid confirmation request.");
            }

            await _authService.VerifyEmail(new VerificationDTO { Email = email, VerificationToken=token });
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordDTO forgotPasswordDTO)
        {
            await _authService.ForgotPassword(forgotPasswordDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDTO resetPasswordDTO)
        {
            await _authService.ResetPassword(resetPasswordDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPost("Revoke")]
        public async Task<IActionResult> Revoke([FromForm] RevokeDTO revokeDTO)
        {
            await _authService.Revoke(revokeDTO);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPost("RevokeAll")]
        public async Task<IActionResult> RevokeAll()
        {
            await _authService.RevokeAll();
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
