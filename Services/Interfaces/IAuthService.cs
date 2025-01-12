using AirlineBookingWebApi.Models.DTOs;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task RegisterAsync(RegisterDTO registerDTO);
        Task ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<bool> VerifyEmail(VerificationDTO verifyEmailDTO);
        Task Revoke(RevokeDTO revokeDTO);
        Task RevokeAll();
    }
}
