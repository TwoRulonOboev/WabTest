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
            string expectedTitle = "������� ���-�����";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("��������� ����� TestTitle: " + (expectedTitle == actualTitle ? "�������" : "�� �������"));
        }

        [Test]
        public void TestObjectVisibility()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.CssSelector(".logo"));
            Assert.IsTrue(element.Displayed);
            Console.WriteLine("��������� ����� TestObjectVisibility: " + (element.Displayed ? "�������" : "�� �������"));
        }

        [Test]
        public void TestLink()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.LinkText("��������"));
            element.Click();
            string expectedUrl = "https://rusprolife.ru/contacts/";
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
            Console.WriteLine("��������� ����� TestLink: " + (expectedUrl == actualUrl ? "�������" : "�� �������"));
        }

        [Test]
        public void TestTextField()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.Name("s"));
            element.SendKeys("test");
            element.Submit();
            string expectedTitle = "���������� ������: test";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("��������� ����� TestTextField: " + (expectedTitle == actualTitle ? "�������" : "�� �������"));
        }

        [Test]
        public void TestButton()
        {
            driver.Navigate().GoToUrl("https://rusprolife.ru/");
            IWebElement element = driver.FindElement(By.CssSelector(".search-submit"));
            element.Click();
            string expectedTitle = "���������� ������:";
            string actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            Console.WriteLine("��������� ����� TestButton: " + (expectedTitle == actualTitle ? "�������" : "�� �������"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}


//������ ��� ����� ���������: ��������� ��������,
//��������� �������� � ������� �� ������,��������������.
//��������� ���� ��������� ��������� ���� ������ � ���������, ��� ��������� �������� �������� ��������� �����.
//����� ���� ��������� ������� �� ������ ������ � ���������, ��� ��������� �������� ��������� �� "���������� ������:". 