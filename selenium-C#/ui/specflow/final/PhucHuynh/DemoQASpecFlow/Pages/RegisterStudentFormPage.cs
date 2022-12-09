using System.Threading;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using System.Reflection;
using System;
using System.IO;

namespace DemoQASpecFlow.Pages
{
    public class RegisterStudentFormPage
    {
        //Web elements
        private WebObject _btnLoadForm = new WebObject(By.XPath("//span[text()='Practice Form']"), "Load Form");
        private WebObject _txtFirstName = new WebObject(By.Id("firstName"), "First Name textbox");
        private WebObject _txtLastName = new WebObject(By.Id("lastName"), "Last Name textbox");
        private WebObject _txtUserEmail = new WebObject(By.Id("userEmail"), "User Email");
        private string _genderPath = "//label[text()='{0}']";
        private WebObject _txtUserNumber = new WebObject(By.Id("userNumber"), "userNumber");
        private WebObject _dtpDateOfBirh = new WebObject(By.Id("dateOfBirthInput"), "Date of Birth");
        private WebObject _ddlSelectMonth = new WebObject(By.XPath("//select[contains(@class,'month-select')]"), "Month Select");
        private WebObject _ddlSelectYear = new WebObject(By.XPath("//select[contains(@class,'year-select')]"), "Month Select");
        private string _dayPath = "//div[not(contains(@class,'outside')) and text()='{0}']";
        private string _statePath = "//div[@id='state']/./descendant::div[text()='{0}']";
        private string _cityPath = "//div[@id='city']/./descendant::div[text()='{0}']";
        private string _hobbiesPath = "//label[contains(@for,'checkbox') and text()='{0}']";
        private WebObject _txtSubjects = new WebObject(By.CssSelector("#subjectsInput"), "Subject Textbox");
        private string _specificSubjectPath = "//div[text()='{0}']";
        private WebObject _txaCurrent = new WebObject(By.Id("currentAddress"), "Current Address");
        private WebObject _ddlState = new WebObject(By.CssSelector("#state"), "State Dropdown List");
        private WebObject _ddlCity = new WebObject(By.CssSelector("#city"), "City Dropdown List");
        private WebObject _btnChooseFile = new WebObject(By.CssSelector("#uploadPicture"), "Upload picture");
        private WebObject _btnSubmit = new WebObject(By.Id("submit"), "submit button");

        //Page method
        public void VisitRegisterStudentForm()
        {
            DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("RegisterStudentURL"));
        }
        //CHOOSE GENDER
        private WebObject _getRdoChosenGender(string gender)
        {
            return new WebObject(By.XPath(string.Format(_genderPath, gender)), $"Gender {gender}");
        }
        public void ChooseGender(string gender)
        {
            DriverUtils.ClickOnElement(_getRdoChosenGender(gender));
        }
        //CHOOSE BIRTHDAY
        public void ChooseDateofBirthContainer()
        {
            DriverUtils.ClickOnElement(_dtpDateOfBirh);
        }
        public void ChooseYear(string year)
        {
            DriverUtils.SelectOptionByText(_ddlSelectYear, year);
        }
        public void ChooseMonth(string month)
        {
            DriverUtils.SelectOptionByText(_ddlSelectMonth, month);
        }
        private WebObject _getBtnDay(string day)
        {
            return new WebObject(By.XPath(string.Format(_dayPath, day)), $"Day {day}");
        }
        public void ChooseDay(string day)
        {
            DriverUtils.ClickOnElement(_getBtnDay(day));
        }
        public void ChooseSpecificDateOfBirth(string date)
        {
            char[] delimeters = { ' ', ',' };
            string[] holder = date.Split(delimeters);
            string day = holder[0];
            string month = holder[1];
            string year = holder[2];
            if (Int32.Parse(day) < 10)
            {
                day = day.Substring(1, 1);
            }
            ChooseDateofBirthContainer();
            ChooseYear(year);
            ChooseMonth(month);
            ChooseDay(day);
        }

        //State-City Option
        private WebObject _getDdlStateOption(string state)
        {
            return new WebObject(By.XPath(string.Format(_statePath, state)), $"State {state}");
        }
        public void SelectState(string state)
        {
            DriverUtils.ClickOnElement(_ddlState);
            DriverUtils.ClickOnElement(_getDdlStateOption(state));
        }
        private WebObject _getDdlCityOption(string city)
        {
            return new WebObject(By.XPath(string.Format(_cityPath, city)), $"City {city}");
        }
        public void SelectCity(string city)
        {
            DriverUtils.ClickOnElement(_ddlCity);
            DriverUtils.ClickOnElement(_getDdlCityOption(city));
        }
        //Hobbies
        private WebObject _getChkHobbies(string hobbies)
        {
            return new WebObject(By.XPath(string.Format(_hobbiesPath, hobbies)), "Hobby");
        }
        public void ClickOnHobby(string hobbies)
        {
            string[] storedHobbies = hobbies.Split(", ");
            foreach (string hobby in storedHobbies)
            {
                DriverUtils.ClickOnElement(_getChkHobbies(hobby));
            }
        }
        // Upload image
        public void UploadPicture(string imageURL)
        {
            string imagePath = Path.GetFullPath(Path.Combine("TestData", imageURL));
            Console.WriteLine(imagePath);
            DriverUtils.EnterText(_btnChooseFile, imagePath);
        }
        //Fill SubjectName
        private WebObject _getDdlSpecificSubject(string subject)
        {
            return new WebObject(By.XPath(string.Format(_specificSubjectPath, subject)), "Subject");
        }
        public void ChooseSubjects(string subjects)
        {
            char[] delimiterChars = { ' ', ',' };
            string[] storedSubjects = subjects.Split(delimiterChars);
            foreach (string subject in storedSubjects)
            {
                DriverUtils.EnterText(_txtSubjects, subject);
                DriverUtils.KeyPressTab();
            }
        }
        public void InputDataIntoAllFields(string firstName, string lastName, string email, string gender, string mobileNumber, string birthDay, string subjects, string hobbies, string picture, string currentAddress, string state, string city)
        {
            DriverUtils.EnterText(_txtFirstName, firstName);
            DriverUtils.EnterText(_txtLastName, lastName);
            if (email != "")
            {
                DriverUtils.EnterText(_txtUserEmail, email);
            }
            ChooseGender(gender);
            DriverUtils.EnterText(_txtUserNumber, mobileNumber);
            if (birthDay != "")
            {
                ChooseSpecificDateOfBirth(birthDay);
            }
            if (subjects != "")
            {
                ChooseSubjects(subjects);
            }
            if (hobbies != "")
            {
                ClickOnHobby(hobbies);
            }
            if (picture != "")
            {
                UploadPicture(picture);
            }
            if (currentAddress != "")
            {
                DriverUtils.EnterText(_txaCurrent, currentAddress);
            }
            DriverUtils.KeyPressEnd();
            if (state != "")
            {
                SelectState(state);
                if (city != "")
                {
                    SelectCity(city);
                }
            }


        }
        public void ClickBtnSubmit()
        {
            DriverUtils.ClickOnElement(_btnSubmit);
        }
    }
}