

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ProjectManagement.AutomatedTests
{
    public class HomePage
    {

        private IWebDriver webDriver;
        private By loginButtonLocator = By.LinkText("Login");
        private By registerButtonLocator = By.LinkText("Register");

        public HomePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        //public LoginPage GoToLoginPage()
        //{
        //    webDriver.FindElement(loginButtonLocator).Click();
        //    return new LoginPage(webDriver);
        //}

        public RegisterPage GoToRegisterPage()
        {
            webDriver.FindElement(registerButtonLocator).Click();
            return new RegisterPage(webDriver);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:7256/");
        }
    }
}
