namespace App.Service.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswwordResetEmailAsync(string email);
    }
}
