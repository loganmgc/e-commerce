using System.Net.Mail;
using App.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using App.Data.Repositories.Interfaces;
using System.Net;

namespace App.Service.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _password;

        public EmailService(IConfiguration config, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _config = config;
            _smtpServer = _config["EmailSettings:SmtpServer"];
            _port = int.Parse(_config["EmailSettings:Port"]);
            _senderEmail = _config["EmailSettings:SenderEmail"];
            _password = _config["EmailSettings:Password"];
        }

        public async Task SendPasswwordResetEmailAsync(string email)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            user.ResetPasswordToken = Guid.NewGuid().ToString("n");
            _userRepo.Update(user);
            await _userRepo.SaveAsync();

            using SmtpClient client = new(_smtpServer, _port)
            {
                Credentials = new NetworkCredential(_senderEmail, _password),
                EnableSsl = true
            };

            MailMessage mail = new()
            {
                From = new MailAddress(_senderEmail),
                Subject = "Password Reset",
                Body = $@"
            <h2>Password Reset Request</h2>
            <p>Click on the link below to reset your password:</p>
            <p><a href='https://localhost:7114/renew-password/{user.ResetPasswordToken}'>Reset Password</a></p>
            <p>Your password reset code: {user.ResetPasswordToken}</p>
            <p>If you did not make this request, you can ignore this email.</p>",
                IsBodyHtml = true,
            };
            mail.To.Add(user.Email);

            await client.SendMailAsync(mail);
        }
    }
}
