namespace App.Service.Models.UserDTOs
{
    public class RenewPasswordWithVerificationCodeDto
    {
        public string VerificationCode { get; set; } = null!;
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
