using Onboarding.Api.Models;

public interface IEmailSender
{
    Task SendEmailAsync(string to, Employee employee);
}