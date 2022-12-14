using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;


namespace AutomationLitres
{
  public class LitresHomePage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string targetUrl = "https://www.litres.ru/";
    private string email = "oksuroyy@gmail.com";
    private string password = "Mutabor2003";

    private string xPathSearchButton = "//form[@action='/pages/rmd_search/']/div/button";
    private string xPathSearchFieldInput = "//form[@action='/pages/rmd_search/']/div/input";

    private string xPathEnterFieldInput = "//a[@href='/pages/login/']"; //кнопка войти
    private string xPathEmailButton = "//button[@type='submit' and @class='ButtonV1-module__button AuthorizationPopup-module__button ButtonV1-module__button__primary ButtonV1-module__button__orange']"; //кнопка email
    private string xPathEmailFieldInput = "//input[@name='email']"; //поле для ввода email
    private string xPathContinueButton = "//button[@type='submit' and @class='ButtonV1-module__button AuthorizationPopup-module__button ButtonV1-module__button__primary ButtonV1-module__button__orange']"; //продолжить
    private string xPathPasswordInput = "//input[@name='pwd']"; //поле для ввода пароля
    private string xPathSubmitButton = "//button[@type='submit' and @class='ButtonV1-module__button AuthorizationPopup-module__button ButtonV1-module__button__primary ButtonV1-module__button__orange']"; //продолжить

    public LitresHomePage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(4000));
    }
    public void OpenTargetPage()
    {
      Thread.Sleep(3000);
      driverChrome.Navigate().GoToUrl(targetUrl);

      Thread.Sleep(5000);
      IWebElement loginButton = driverChrome.FindElement(By.XPath(xPathEnterFieldInput)); 
      Thread.Sleep(5000);
      loginButton.Click();

      Thread.Sleep(5000);
      driverChrome.FindElement(By.XPath(xPathEmailButton)).Click();
      Thread.Sleep(5000);

      wait.Until(drv => drv.FindElement(By.XPath(xPathEmailFieldInput))).Click();
      Thread.Sleep(5000);
      driverChrome.FindElement(By.XPath(xPathEmailFieldInput)).SendKeys(email);

      Thread.Sleep(7000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathContinueButton))).Click();
      Thread.Sleep(7000);

      wait.Until(drv => drv.FindElement(By.XPath(xPathPasswordInput))).Click();
      Thread.Sleep(5000);
      driverChrome.FindElement(By.XPath(xPathPasswordInput)).SendKeys(password);
      Thread.Sleep(7000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathSubmitButton))).Click();
    }
    public IWebElement FindSearchFieldInput()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchFieldInput)));
      return driverChrome.FindElement(By.XPath(xPathSearchFieldInput));
    }
    public LitresSearchPage GoToSearchResultsPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchButton))).Click();
      return new LitresSearchPage(driverChrome);
    }

  }
}
