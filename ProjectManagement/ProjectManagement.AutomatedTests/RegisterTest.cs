using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectManagement.AutomatedTests
{
    [TestClass]
    public class RegisterTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Set up the WebDriver
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7256/Identity/Account/Register"); 
        }

        [TestMethod]
        public void RegisterPage_ElementsExist()
        {
            // Verify that the necessary elements exist on the page
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("registerForm")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("registerSubmit")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("registerSubmit")).Enabled);
        }

        [TestMethod]
        public void RegisterPage_Registration_Success()
        {
            // Fill in the registration form
            driver.FindElement(By.Id("registerForm")).FindElement(By.Id("Input_Name")).SendKeys("John Doe");
            driver.FindElement(By.Id("registerForm")).FindElement(By.Id("Input_Address")).SendKeys("123 Main St");
            driver.FindElement(By.Id("registerForm")).FindElement(By.Id("Input_Email")).SendKeys("john.doe@example.com");
            driver.FindElement(By.Id("registerForm")).FindElement(By.Id("Input_Password")).SendKeys("Password123!");
            driver.FindElement(By.Id("registerForm")).FindElement(By.Id("Input_ConfirmPassword")).SendKeys("Password123!");

            // Submit the form
            driver.FindElement(By.Id("registerSubmit")).Click();

            HomePage homePage = new HomePage(driver);
            homePage.GoToPage();
            RegisterPage registerPage = homePage.GoToRegisterPage();
            registerPage.Register("John Doe", "123 Main St", "john.doe@example.com", "Password123!", "Password123!");
            // Verify successful registration
            Assert.IsTrue(driver.Url.Contains("https://localhost:7256/")); 
            Assert.AreEqual("Registration Successful", driver.FindElement(By.TagName("h2")).Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the WebDriver
            driver.Quit();
        }
    }
}