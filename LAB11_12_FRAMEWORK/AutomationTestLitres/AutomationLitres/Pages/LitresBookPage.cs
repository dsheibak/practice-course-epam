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

namespace AutomationLitres.Pages
{
  public class LitresBookPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;

    private string xPathUserBookPageButton = "//*[@id='litres_header']/header/div[2]/span/div/a";
    private string xPathAddToBasketButton = "//button[@data-action='addbasket']";

    private string xPathMarkAsReadButton = "//*[@id='page-wrap']/div[3]/div[2]/div/div[1]/div/div[2]/div[8]/div/div[@class='mark_as_read-btn']";
    private string xPathMakeAsReadActivateLabel = "//*[@id='page-wrap']/div[3]/div[2]/div/div[1]/div/div[2]/div[8]/div/div[@class='mark_as_read-btn' and text()='Прочитана']";

    private string xPathOpenBookSubMenu = "//*[@id='page-wrap']//div[@class='mark_as_read-more-btn']";
    private string xPathAddToNewListButton = "//div[@class='user-list-item__inner-wrap']//div[@class='user-list-item__text' and text()='В новый список']";
    private string xPathInputListNameField = "//input[@placeholder='Название списка']";
    private string xPathSaveListButton = "//div[@class='user-list-create__buttons-wrapper']//button[@type='submit']";


    public LitresBookPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public IWebElement FindAddToBasketButton()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathAddToBasketButton)));
    }

    public UserBookPage GoToUserBookPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookPageButton))).Click();
      return new UserBookPage(driver, wait);
    }

    public IWebElement FindMarkAsReadButton()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathMarkAsReadButton)));
    }

    public string GetButtonMarkAsReadStatus()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathMakeAsReadActivateLabel))).Text;
    }

    public IWebElement CreateUserBookList(string listName)
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathOpenBookSubMenu))).Click();
      wait.Until(drv => drv.FindElement(By.XPath(xPathAddToNewListButton))).Click();
      IWebElement inputField = driver.FindElement(By.XPath(xPathInputListNameField));
      inputField.Click();
      inputField.SendKeys(listName);
      return wait.Until(drv => drv.FindElement(By.XPath(xPathSaveListButton)));
    }

  }
}
