using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using System.Collections.Generic;
using DemoQASpecFlow.Models;

namespace DemoQASpecFlow.Pages
{
    public class NavigationPage
    {
        private WebObject _btnLogin = new WebObject(By.XPath("//span[text()='Login']"), "Login Button");
        private WebObject _btnBookStore = new WebObject(By.XPath("//span[text()='Book Store']/.."), "BookStore button");
        private WebObject _btnProfile = new WebObject(By.XPath("//span[text()='Profile']/.."), "Login Button");
        public void ClickOnbtnBookStore()
        {
            DriverUtils.ClickOnElement(_btnBookStore);
        }
        public void ClickOnbtnProfile()
        {
            DriverUtils.ClickOnElement(_btnProfile);
        }

    }
}