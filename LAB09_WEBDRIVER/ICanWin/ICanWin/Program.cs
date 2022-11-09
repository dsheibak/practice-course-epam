// Открыть https://pastebin.com или аналогичный сервис в любом браузере
// Создать New Paste со следующими деталями:
// Код: "Hello from WebDriver"
// Paste Expiration: "10 Minutes"
//Paste Name / Title: "helloweb"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace ICanWin
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        IWebDriver driverChrome = new ChromeDriver();
        driverChrome.Navigate().GoToUrl("https://pastebin.com");
        driverChrome.Manage().Window.Maximize();

        driverChrome.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");
        driverChrome.FindElement(By.Id("select2-postform-expiration-container")).Click();
        driverChrome.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();
        driverChrome.FindElement(By.Id("postform-name")).SendKeys("helloweb");
        driverChrome.FindElement(By.XPath("//button[@class='btn -big' and @type='submit']")).Click();

        Thread.Sleep(5000);

        driverChrome.Close();
        driverChrome.Quit();
      }
      catch (ThreadInterruptedException e)
      {
        Console.WriteLine("Thread Interrupted " + e);
      }

    }
  }
}
