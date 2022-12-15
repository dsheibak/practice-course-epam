using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using AutomationLitres;
using System.IO;

namespace AutomationLitres.Pages
{
  public class LoginPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;
    private const string TARGET_URL = "https://www.litres.ru/";

    private string xPathEnterFieldInput = "//a[@href='/pages/login/']"; // кнопка войти
    private string xPathEmailButton = "//button//div[text()='Электронная почта']"; // кнопка email
    private string xPathEmailFieldInput = "//input[@name='email']"; // поле для ввода email
    private string xPathContinueButton = "//button//div[text()='Продолжить']"; // продолжить
    private string xPathPasswordInput = "//input[@name='pwd']"; // поле для ввода пароля
    private string xPathSubmitButton = "//button//div[text()='Войти']"; // войти

    public LoginPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public void OpenPage()
    {
      driver.Navigate().GoToUrl(TARGET_URL);
    }

    public void Login(string email, string password)
    {
      Thread.Sleep(5000);
      driver.FindElement(By.XPath(xPathEnterFieldInput)).Click();
      Thread.Sleep(5000);
      driver.FindElement(By.XPath(xPathEmailButton)).Click();
      Thread.Sleep(5000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathEmailFieldInput))).Click();
      driver.FindElement(By.XPath(xPathEmailFieldInput)).SendKeys(email);
      Thread.Sleep(5000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathContinueButton))).Click();
      Thread.Sleep(5000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathPasswordInput))).Click();
      Thread.Sleep(3000);
      driver.FindElement(By.XPath(xPathPasswordInput)).SendKeys(password);
      Thread.Sleep(5000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathSubmitButton))).Click();
      Thread.Sleep(5000);
    }

  }
}
