using System.ComponentModel.DataAnnotations;

namespace OnboardingApi.Models
{
    public class OnboardRequest
    {
        
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    
        
    }
}