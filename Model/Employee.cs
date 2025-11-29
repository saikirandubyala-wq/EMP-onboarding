using System;
using SQLitePCL;

namespace Onboarding.Api.Models
{
    public class Employee

    {
      
        public Guid Id { get; set; }    

         //public string EmployeeId{get; set;}        
        public string Email { get; set; } = "";   
        public DateTime DateOfJoining { get; set; } 
        public string Role { get; set; } = "Engineer";
          public Employee(string email, string role, DateTime dateOfJoining)
        {
            Id = Guid.NewGuid();
            Email = email;
            Role = role;
            DateOfJoining = dateOfJoining;
           // EmployeeId= GenerateEmployeeId();
        } 
    }
}