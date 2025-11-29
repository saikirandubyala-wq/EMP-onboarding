using Microsoft.AspNetCore.Mvc;
using Onboarding.Api.Models;
using Onboarding.Api.Services;
using OnboardingApi.Models;
using System.Threading.Tasks;


namespace Onboarding.Api.Controllers
{
    [ApiController]
    [Route("api/onboard")]
    public class OnboardingController : ControllerBase
    {
        private readonly OnboardingService _onboardingService;
        private readonly IEmailSender _emailSender;
         private readonly ILogger<OnboardingController> _logger;


        public OnboardingController(OnboardingService onboardingService, IEmailSender emailSender, ILogger<OnboardingController> logger)
        {
            _onboardingService = onboardingService;
            _emailSender = emailSender;
            _logger = logger;
        }

    

        [HttpPost]
public async Task<ActionResult<Employee>> Post([FromBody] OnboardRequest request)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    try
    {
        var employee = await _onboardingService.OnboardAsync(request.Email);
        await _emailSender.SendEmailAsync(request.Email, employee);

        return Ok(employee);
    }
    catch (ApplicationException ex)
    {
        _logger.LogError(ex, "Onboarding failed for {Email}", request.Email);
        return StatusCode(500, "An error occurred during onboarding. Please try again later.");
    }
}
    }
}

