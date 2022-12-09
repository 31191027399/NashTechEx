using System.Security.Cryptography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium.Interactions;

namespace DemoQASpecFlow.Library
{
    public static class DriverUtils
    {
        public static int GetWaitTimeoutSeconds()
        {
            return int.Parse(ConfigurationHelper.GetConfigurationByKey("Timeout.Webdriver.Wait.Seconds"));
        }
        public static void GoToUrl(string url)
        {
            Context.GetWebDriver().Url = url;
            Context.Node.Pass("Open URL: " + url);
        }

        //Wait Element 
        public static IWebElement WaitForElementToBeVisible(WebObject webObject)
        {
            try
            {
                var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementIsVisible(webObject.By));
            }
            catch (WebDriverTimeoutException exception)
            {
                var message = $"Element is not visible as expected. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }

        public static IWebElement WaitForElementToBeClickable(WebObject webObject)
        {
            try
            {
                var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementToBeClickable(webObject.By));
            }
            catch (WebDriverTimeoutException exception)
            {
                var message = $"Element is not clickable as expected. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }

        public static void WaitForElementToBeInvisible(WebObject wobject)
        {
            try
            {
                var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(wobject.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"Element is still visible. Element information: {wobject.Name}";
                Console.WriteLine(message);
                Context.Node.Pass(message);
            }
        }

        public static void WaitForPageLoadCompletely()
        {

            var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
            wait.Until(driver1 => ((IJavaScriptExecutor)Context.GetWebDriver()).ExecuteScript("return document.readyState").Equals("complete"));
        }

        //Get attribute of an Element
        public static bool IsElementDisplayed(WebObject webObject)
        {
            bool result;
            var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
            try
            {
                result = wait.Until(ExpectedConditions.ElementIsVisible(webObject.By)).Displayed;
                Console.WriteLine(webObject.Name + " is displayed as expected");
                Context.Node.Pass(webObject.Name + " is displayed as expected");
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
                Console.WriteLine(webObject.Name + " is not displayed as expected");
                Context.Node.Pass(webObject.Name + " is not displayed as expected");
            }
            return result;
        }

        public static string GetTextFromElement(WebObject webObject)
        {
            try
            {
                var element = WaitForElementToBeVisible(webObject);
                Console.WriteLine("Get text from " + webObject.Name);
                Context.Node.Pass("Get text from " + webObject.Name);
                return element.Text;
            }
            catch (WebDriverException exception)
            {
                var message = $"An error happens when trying to get text from element. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }

        //Action on Element
        public static void ClickOnElement(WebObject webObject)
        {
            try
            {
                var element = WaitForElementToBeClickable(webObject);
                element.Click();
                Console.WriteLine("Click on " + webObject.Name);
                Context.Node.Pass("Click on " + webObject.Name);
            }
            catch (WebDriverException exception)
            {
                var message = $"An error happens when trying to click on an element. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }

        public static void EnterText(WebObject webObject, string text)
        {
            try
            {
                var element = WaitForElementToBeVisible(webObject);
                element.Clear();
                element.SendKeys(text);
                Console.WriteLine(text + " is entered in the " + webObject.Name + " field.");
                Context.Node.Pass(text + " is entered in the " + webObject.Name + " field.");
            }
            catch (WebDriverException exception)
            {
                var message = $"An error happens when trying to enter text to a field. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }

        public static void MoveToElement(WebObject webObject)
        {
            try
            {
                var element = WaitForElementToBeClickable(webObject);
                new Actions(Context.GetWebDriver())
                   .MoveToElement(element)
                   .Perform();
                Console.WriteLine("Scroll to " + webObject.Name);
                Context.Node.Pass("Scroll to " + webObject.Name);
            }
            catch (WebDriverException exception)
            {
                var message = $"An error happens when trying to move to an element. Element information: {webObject.Name}";
                Context.Node.Fail(message);
                throw exception;
            }
        }
        public static void ClearText(WebObject webObject)
        {
            var element = WaitForElementToBeClickable(webObject);
            element.SendKeys(Keys.LeftControl + "a" + Keys.Delete);
            Console.WriteLine("Empty " + webObject.Name + " field.");
            Context.Node.Pass("Empty " + webObject.Name + " field.");
        }
        public static void KeyPressPageDown(WebObject webObject)
        {
            var element = WaitForElementToBeVisible(webObject);
            element.SendKeys(Keys.PageDown);
        }
        public static void SelectOptionByText(WebObject webObjects, string text)
        {
            var element = WaitForElementToBeVisible(webObjects);
            var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            var select = new SelectElement(element);
            select.SelectByText(text);
        }
        public static void KeyPressTab()
        {
            Actions action = new Actions(Context.GetWebDriver());
            action.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
        }
        public static void KeyPressEnd()
        {
            WaitForPageLoadCompletely();
            Actions action = new Actions(Context.GetWebDriver());
            action.SendKeys(OpenQA.Selenium.Keys.End).Perform();
        }
        public static void HideAds()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Context.GetWebDriver();
            js.ExecuteScript("document.querySelector('#app > footer').remove()");
            js.ExecuteScript("document.getElementById('fixedban').remove()");
        }
        public static string ResolveAlert()
        {
            var wait = new WebDriverWait(Context.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Context.GetWebDriver().SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text;
        }
    }
}