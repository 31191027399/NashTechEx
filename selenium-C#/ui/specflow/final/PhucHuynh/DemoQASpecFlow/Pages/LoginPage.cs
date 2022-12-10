using System.IO;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;

namespace DemoQASpecFlow.Pages
{
    public class LoginPage 
    {
        //Web Element
        private WebObject _txtUserName = new WebObject(By.Id("userName"),"Username");
        private WebObject _txtPassWord = new WebObject(By.Id("password"),"Password");
        private WebObject _btnLogin = new WebObject(By.Id("login"),"login");

      //Page Method
      public void Login(string userName, string password)
      {
        DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("LoginURL"));
        DriverUtils.WaitForPageLoadCompletely();
        DriverUtils.EnterText(_txtUserName,userName);
        DriverUtils.EnterText(_txtPassWord,password);
        DriverUtils.KeyPressEnd();
        DriverUtils.ClickOnElement(_btnLogin);
      }
    }

}