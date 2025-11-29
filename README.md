Employee Onboarding API
A simple ASP.NET Core Web API that allows HR teams to onboard new employees by submitting their email and role. The API stores employee data in a SQLite database and sends a welcome email via SMTP.

 Features
• 	 endpoint to onboard new employees
• 	Validates email and role using data annotations
• 	Saves employee data to SQLite using Entity Framework Core
• 	Sends welcome email asynchronously using SMTP
• 	Swagger UI for interactive API testing and documentation
• 	Clean architecture: Models, Services, Controllers, Interfaces

 Project Structure
/EmployeeOnboardingAPI

 Controllers/
   OnboardingController.cs         Handles POST /api/onboard requests

 Models/
    Employee.cs                     Defines Employee data structure
   OnboardRequest.cs               Validates incoming email and role

 Services/
OnboardingService.cs           Creates and saves Employee to DB
 EmailSender.cs                  Sends welcome email via SMTP

 Interfaces/
 IEmailSender.cs                 Abstraction for email sending logic
Data/
 AppDbContext.cs                    EF Core DbContext for SQLite
 Program.cs                          Entry point, configures app and Swagger
├── appsettings.json                  SMTP and DB configuration


 Technologies Used
• 	ASP.NET Core Web API
• 	Entity Framework Core
• 	SQLite
• 	SMTP (System.Net.Mail)
• 	Swagger (Swashbuckle)

How to Run
1. 	Clone the repository
2. 	Update SMTP settings in appsetings.jason
3. 	Run the project using Visual Studio or 
4. 	Open  to test the API

 Sample Request
POST /api/onboard
Content-Type: application/json

{
  "email": "newhire@example.com",
  "role": "Engineer"
}


 Sample Response
{
  "id": 1,
  "email": "newhire@example.com",
  "role": "Engineer",
  "dateOfJoining": "2025-11-29T01:08:00"
}


