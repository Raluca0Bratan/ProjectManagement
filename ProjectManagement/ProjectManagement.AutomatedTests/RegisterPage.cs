using OpenQA.Selenium;

namespace ProjectManagement.AutomatedTests
{
    public class RegisterPage
    {
        private IWebDriver webDriver;

        public RegisterPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public IWebElement NameTextBox => webDriver.FindElement(By.Id("Input_Name"));
        public IWebElement AddressTextBox => webDriver.FindElement(By.Id("Input_Address"));
        public IWebElement EmailTextBox => webDriver.FindElement(By.Id("Input_Email"));
        public IWebElement PasswordTextBox => webDriver.FindElement(By.Id("Input_Password"));
        public IWebElement ConfirmPasswordTextBox => webDriver.FindElement(By.Id("Input_ConfirmPassword"));
        public IWebElement RegisterButton => webDriver.FindElement(By.Id("registerSubmit"));

        public void Register(string name, string address, string email, string password, string confirmedPassword)
        {
            NameTextBox.Clear();
            NameTextBox.SendKeys(name);

            AddressTextBox.Clear();
            AddressTextBox.SendKeys(address);

            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);

            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);

            ConfirmPasswordTextBox.Clear();
            ConfirmPasswordTextBox.SendKeys(confirmedPassword);

            RegisterButton.Click();
        }
    }
}

