// Services/EmailSender.cs
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Onboarding.Api.Models;

namespace Onboarding.Api.Services
{
   public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly IConfiguration _configuration;

    public EmailSender(ILogger<EmailSender> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string to, Employee employee)
    {
        try
        {
            var message = new MailMessage("hr@company.com", to)
            {
                Subject = "Welcome to the team!",
                Body = $"Hi {employee.Email},your employeeId is  {employee.Id}, your role is {employee.Role}. Welcome aboard!"
            };

            using var client = new SmtpClient(_configuration["Smtp:Host"], int.Parse(_configuration["Smtp:Port"]))
            {
                Credentials = new NetworkCredential(_configuration["Smtp:User"], _configuration["Smtp:Pass"]),
                EnableSsl = true
            };

            _logger.LogInformation("Sending welcome email to {Email}", to);
            await client.SendMailAsync(message);
            _logger.LogInformation("Email sent successfully to {Email}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Email}", to);
            throw new ApplicationException("Email sending failed", ex);
        }
    }
}
}