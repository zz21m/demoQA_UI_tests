using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.PageObjects;
using Tests.TestData;
using Tests.TestData.Model;

namespace Tests.Forms
{
    public class RegistrationForm : PageWithMenu
    {
        private readonly TextField firstNameTF = new(By.Id("firstName"), "First name text field");
        private readonly TextField lastNameTF = new(By.Id("lastName"), "Last name text field");
        private readonly TextField ageTF = new(By.Id("age"), "Age text field");
        private readonly TextField emailTF = new(By.Id("userEmail"), "Email text field");
        private readonly TextField salaryTF = new(By.Id("salary"), "Salary text field");
        private readonly TextField departmentTF = new(By.Id("department"), "Department text field");
        private readonly Button submitButton = new(By.Id("submit"), "Submit button");
        public RegistrationForm() : base(By.Id("registration-form-modal"), "Registration page")
        {

        }

        public void FillUser(User user)
        {
            firstNameTF.SetValue(user.FirstName);
            lastNameTF.SetValue(user.LastName);
            emailTF.SetValue(user.Email);
            ageTF.SetValue(user.Age);
            salaryTF.SetValue(user.Salary);
            departmentTF.SetValue(user.Department);
        }

        public void Submit()
        {
            submitButton.Click();
        }

    }
}
