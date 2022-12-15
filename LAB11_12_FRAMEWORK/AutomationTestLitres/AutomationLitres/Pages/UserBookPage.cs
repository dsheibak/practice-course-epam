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
  public class UserBookPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;

    private string xPathUserBookBasketPanel = "//*[@id='my-books-list__basket']/a"; // вкладка "корзина"
    private string xPathUserBookListTitle = "//*[@id='my-books-list__bookshelf']/a"; // вкладка "списки"
    private string xPathBookTitle = "//a[@title='Игра престолов']";

    private string xPathMenuDelete = "//span[text()='Игра престолов']/../../..//following-sibling::div/img"; // иконка три точки
    private string xPathDeleteButton = "//span[text()='Игра престолов']/../../..//following-sibling::div//button[@data-action='dropbasket']"; // кнопка "удалить из корзины"

    private string xPathCreateUserBookListButton = "//*[@id='MyFoldersListWrapper']/div[1]"; // "создать новый список"
    private string xPathListNameInput = "//*[@id='editCaption']"; // поле для ввода "название списка"

    private string xPathSaveList = "//*[@id='editCaptionYesButton']"; // кнопка "сохранить"
    public UserBookPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public IWebElement GetBookNameFromBasket()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookBasketPanel))).Click();
      return wait.Until(drv => drv.FindElement(By.XPath(xPathBookTitle)));
    }

    public IWebElement GetBookNameFromUserReadedList()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookListTitle))).Click();
      return wait.Until(drv => drv.FindElement(By.XPath(xPathBookTitle)));
    }

    public IWebElement GetUserReadedList()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookListTitle)));
    }

    public IWebElement RemoveBookFromBasket()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookBasketPanel))).Click();

      wait.Until(drv => drv.FindElement(By.XPath(xPathMenuDelete))).Click();
      wait.Until(drv => drv.FindElement(By.XPath(xPathDeleteButton))).Click();

      Thread.Sleep(3000);

      return driver.FindElement(By.XPath(xPathBookTitle));
    }

    public IWebElement CreateUserBookList(string createdListName)
    {
      driver.FindElement(By.XPath(xPathUserBookListTitle)).Click();
      driver.FindElement(By.XPath(xPathCreateUserBookListButton)).Click();
      Thread.Sleep(3000);
      driver.FindElement(By.XPath(xPathListNameInput)).SendKeys(createdListName);
      return driver.FindElement(By.XPath(xPathSaveList));
    }

    public IWebElement CheckUserListsOnAddedListPresence(string listName)
    {
      string pattern = "//p[text()='" + listName + "']";
      return driver.FindElement(By.XPath(pattern));
    }

    public IWebElement CheckUserListsListPresenceByHrefs(string listName)
    {
      driver.FindElement(By.XPath(xPathUserBookListTitle)).Click();
      string pattern = "//a[text()='" + listName + "']";
      return driver.FindElement(By.XPath(pattern));
    }

  }
}
