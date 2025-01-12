using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AirlineBookingWebApi.Models.DTOs
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string ResetPasswordToken { get; set; }
    }
}
