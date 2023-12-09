using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebTesting
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestTitle()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            string expectedTitle = "Русский про-жизнь";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("Результат теста TestTitle: " + (expectedTitle == actualTitle ? "Пройден" : "Не пройден"));
        }

        [Test]
        public void TestObjectVisibility()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.CssSelector(".logo"));
            Assert.IsTrue(element.Displayed);
            Console.WriteLine("Результат теста TestObjectVisibility: " + (element.Displayed ? "Пройден" : "Не пройден"));
        }

        [Test]
        public void TestLink()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.LinkText("Контакты"));
            element.Click();
            string expectedUrl = "https://rusprolife.ru/contacts/";
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
            Console.WriteLine("Результат теста TestLink: " + (expectedUrl == actualUrl ? "Пройден" : "Не пройден"));
        }

        [Test]
        public void TestTextField()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.Name("s"));
            element.SendKeys("test");
            element.Submit();
            string expectedTitle = "Результаты поиска: test";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("Результат теста TestTextField: " + (expectedTitle == actualTitle ? "Пройден" : "Не пройден"));
        }

        [Test]
        public void TestButton()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.CssSelector(".search-submit"));
            element.Click();
            string expectedTitle = "Результаты поиска:";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("Результат теста TestButton: " + (expectedTitle == actualTitle ? "Пройден" : "Не пройден"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}


//Первые три теста проверяют: заголовок страницы,
//видимость объектов и переход по ссылке,соответственно.
//Четвертый тест заполняет текстовое поле поиска и проверяет, что заголовок страницы содержит введенный текст.
//Пятый тест эмулирует нажатие на кнопку поиска и проверяет, что заголовок страницы изменился на "Результаты поиска:". 