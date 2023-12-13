using Microsoft.Extensions.Configuration;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimplewebcalculatorUITests
{
    public class UITests : IDisposable
    {
        private IWebDriver _driver;
        private IConfiguration _configuration;
        private string _webAppUrl;

        public UITests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            _webAppUrl = _configuration["WebAppUrl"];

            _driver = new ChromeDriver();
        }

        [Fact]
        public void CalculatorUI_AddOperation_ComputesCorrectResult()
        {
            _driver.Navigate().GoToUrl(_webAppUrl);

            _driver.FindElement(By.Name("Value1")).SendKeys("5");
            _driver.FindElement(By.Name("Value2")).SendKeys("3");
            _driver.FindElement(By.Name("Operation")).SendKeys("Add");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            var result = _driver.FindElement(By.Id("result")).Text; // Ensure your view has an element with id="result" for displaying the result
            Assert.Equal("Result: 8", result);
        }

        public void CalculatorUI_SubtractOperation_ComputesCorrectResult()
        {
            _driver.Navigate().GoToUrl(_webAppUrl);

            _driver.FindElement(By.Name("Value1")).SendKeys("5");
            _driver.FindElement(By.Name("Value2")).SendKeys("3");
            _driver.FindElement(By.Name("Operation")).SendKeys("Subtract");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            var result = _driver.FindElement(By.Id("result")).Text; // Ensure your view has an element with id="result" for displaying the result
            Assert.Equal("Result: 2", result);
        }

        public void CalculatorUI_MultiplyOperation_ComputesCorrectResult()
        {
            _driver.Navigate().GoToUrl(_webAppUrl);

            _driver.FindElement(By.Name("Value1")).SendKeys("5");
            _driver.FindElement(By.Name("Value2")).SendKeys("3");
            _driver.FindElement(By.Name("Operation")).SendKeys("Multiply");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            var result = _driver.FindElement(By.Id("result")).Text; // Ensure your view has an element with id="result" for displaying the result
            Assert.Equal("Result: 15", result);
        }

        public void CalculatorUI_DivideOperation_ComputesCorrectResult()
        {
            _driver.Navigate().GoToUrl(_webAppUrl);

            _driver.FindElement(By.Name("Value1")).SendKeys("5");
            _driver.FindElement(By.Name("Value2")).SendKeys("3");
            _driver.FindElement(By.Name("Operation")).SendKeys("Divide");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            var result = _driver.FindElement(By.Id("result")).Text; // Ensure your view has an element with id="result" for displaying the result
            Assert.Equal("Result: 15", result);
        }
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
