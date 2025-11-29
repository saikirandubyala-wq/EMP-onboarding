using Onboarding.Api.Data;
using Onboarding.Api.Models;

public class OnboardingService
{
    private readonly OnboardingDbContext _context;
    private readonly ILogger<OnboardingService> _logger;

    public OnboardingService(OnboardingDbContext context, ILogger<OnboardingService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Employee> OnboardAsync(string email)
    {
        try
        {
            string role = "Engineer";
            var employee = new Employee(email, role, DateTime.UtcNow);

            _logger.LogInformation("Attempting to save employee {Email} with role {Role}", email, "Engineer");

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Employee {Id} saved successfully at {Time}", employee.Id, DateTime.Now);

            return employee;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving employee {Email} to database", email);
            throw new ApplicationException("Database save failed", ex);
        }
    }
}