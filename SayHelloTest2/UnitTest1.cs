using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SayHelloTest2
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory);
            // _driver = new FirefoxDriver(DriverDirectory);  
             _driver = new EdgeDriver(DriverDirectory); 
        }

        [ClassCleanup]
        public static void TearDown()
        {
             _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //_driver.Navigate().GoToUrl("http://localhost:5502/index.htm");
            _driver.Navigate().GoToUrl("file:///C:/andersb/javascript/sayhello/index.htm");
            Assert.AreEqual("Say Hello", _driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("inputField"));
            inputElement1.SendKeys("Anders");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            IWebElement resultElement = _driver.FindElement(By.Id("outputField"));
            Assert.AreEqual("Hello Anders", resultElement.Text);
        }
    }
}