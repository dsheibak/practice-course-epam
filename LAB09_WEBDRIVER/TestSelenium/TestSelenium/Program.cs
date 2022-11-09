using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace TestSelenium
{
  class Program
  {
    static void Main(string[] args)
    {
      IWebDriver driver = new ChromeDriver();

      //Общие таймауты - General Timeouts
      driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
      driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);

      driver.Navigate().GoToUrl("http:www.google.com");
      driver.Manage().Window.Maximize();

      // Задаем локатор (селектор) serachTextBoxSelector с помощью класса By
      By serachTextBoxSelector = By.XPath("//*[@title='Поиск']");

      // Находим Search text box, используя метод FindElement()
      IWebElement element = driver.FindElement(serachTextBoxSelector);

      // Вводим текст в найденный элемент с помощью SendKeys()
      element.SendKeys("learn-automation");

      // Ожидаем, пока элемент не будет найден в DOM
      WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
      By clearInputButton = By.XPath("//*[@aria-label='Очистить']");
      IWebElement button = waiter.Until(webdriver => webdriver.FindElement(clearInputButton));

      // Ожидание проверки того, что элемент присутствует в DOM страницы и виден
      IWebElement element2 = waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='Очистить']")));

      // Ожидание того, что элемент существует
      WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("h1")));

      // Нажимаем на кнопку
      button.Click();

      Thread.Sleep(7000);

      By elementsSearchLocator = By.XPath("//*[@title='Поиск']");
      List<IWebElement> elements = driver.FindElements(elementsSearchLocator).ToList();
      elements.ElementAt(0).SendKeys("learn-automation");

      Thread.Sleep(7000);

      driver.Close();
      driver.Quit();

    }
  }
}
