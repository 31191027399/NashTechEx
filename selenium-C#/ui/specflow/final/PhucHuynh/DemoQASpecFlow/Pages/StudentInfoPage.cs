using OpenQA.Selenium;
using DemoQASpecFlow.Library;

namespace DemoQASpecFlow.Pages
{
    public class StudentInfoPage
    {
        //WebElement
        private WebObject _lblThankYou = new WebObject(By.CssSelector("div[role='document'] div[class~='modal-title']"),"Thank You Label");
        private WebObject _lblName = new WebObject(By.XPath("//td[text()='Student Name']/./following-sibling::td"), "Name");
        private WebObject _lblEmail = new WebObject(By.XPath("//td[text()='Student Email']/./following-sibling::td"), "Email");
        private WebObject _lblGender = new WebObject(By.XPath("//td[text()='Gender']/./following-sibling::td"), "Gender");
        private WebObject _lblDateOfBirth = new WebObject(By.XPath("//td[text()='Date of Birth']/./following-sibling::td"), "Date of Birth");
        private WebObject _lblMobile = new WebObject(By.XPath("//td[text()='Mobile']/./following-sibling::td"), "Mobile");
        private WebObject _lblSubjects = new WebObject(By.XPath("//td[text()='Subjects']/./following-sibling::td"), "Subjects");
        private WebObject _lblHobbies = new WebObject(By.XPath("//td[text()='Hobbies']/./following-sibling::td"), "Hobbies");
        private WebObject _lblPicture = new WebObject(By.XPath("//td[text()='Picture']/./following-sibling::td"), "Picture");
        private WebObject _lblAddress = new WebObject(By.XPath("//td[text()='Address']/./following-sibling::td"), "Address");
        private WebObject _lblStateAndCity = new WebObject(By.XPath("//td[text()='State and City']/./following-sibling::td"), "State and City");

        //Page method
        public string GetThankYouLabel()
        {
            return DriverUtils.GetTextFromElement(_lblThankYou);
        }
        public string GetName()
        {
            return DriverUtils.GetTextFromElement(_lblName);
        }
        public string GetEmail()
        {
            return DriverUtils.GetTextFromElement(_lblEmail);
        }
        public string GetGender()
        {
            return DriverUtils.GetTextFromElement(_lblGender);
        }
        public string GetBirthday()
        {
            return DriverUtils.GetTextFromElement(_lblDateOfBirth);
        }
        public string GetMobile()
        {
            return DriverUtils.GetTextFromElement(_lblMobile);
        }
        public string GetSubjects()
        {
            return DriverUtils.GetTextFromElement(_lblSubjects);
        }
        public string GetHobbies()
        {
            return DriverUtils.GetTextFromElement(_lblHobbies);
        }
        public string GetPicture()
        {
            return DriverUtils.GetTextFromElement(_lblPicture);
        }
        public string GetAddress()
        {
            return DriverUtils.GetTextFromElement(_lblAddress);
        }
        public string GetStateandCity()
        {
            return DriverUtils.GetTextFromElement(_lblStateAndCity);
        }

    }
}