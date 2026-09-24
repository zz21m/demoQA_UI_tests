using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.TestData.Model
{
    public class User
    {
        public required string FirstName { get; set; } 
        public required string LastName { get; set; } 
        public required string Email { get; set; } 
        public required int Age { get; set; }
        public required int Salary { get; set; }
        public required string Department { get; set; } 
    }
}
