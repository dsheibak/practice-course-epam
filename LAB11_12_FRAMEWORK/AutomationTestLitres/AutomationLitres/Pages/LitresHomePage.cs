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
using AutomationLitres.Pages;


namespace AutomationLitres
{
  public class LitresHomePage
  {
    private IWebDriver driver;
    private WebDriverWait wait;

    private string xPathMenuElementAnother = "//div[@class='LowerMenu-module__more']//a"; // пункт меню "Еще"
    private string XPathSubMenuElementPopularAuthors = "//a[@href='/luchshie-avtori/']"; // пункт подменю "Еще" - "Популярные авторы"

    private string xPathSearchFieldInput = "//form[@action='/pages/rmd_search/']/div/input"; // строка поиска на главной странице
    private string xPathSearchButton = "//form[@action='/pages/rmd_search/']/div/button"; // кнопка поиска рядом со строкой поиска

    private string xPathUserBookButton = "//a[@href='/pages/my_books_all/']"; // кнопка "Мои книги"

    private string xPathMenuGenres = "//a[@href='/pages/new_genres/' and text()='Жанры']"; // раздел в меню "Жанры"

    public LitresHomePage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public IWebElement FindMenuElementAnother()
    {
      // поиск пункта меню "Ещё"

      wait.Until(drv => drv.FindElement(By.XPath(xPathMenuElementAnother)));
      return driver.FindElement(By.XPath(xPathMenuElementAnother));
    }
    public PopularAuthorsPage GoToPopularAuthorsPage()
    {
      // переход к странице "Популярные авторы" из меню

      wait.Until(drv => drv.FindElement(By.XPath(XPathSubMenuElementPopularAuthors))).Click();
      return new PopularAuthorsPage(driver, wait);
    }
    public LitresSearchPage GoToSearchResultsPage(string textToType)
    {
      // доступ к странице с результатами поиска
      Thread.Sleep(2000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchFieldInput))).SendKeys(textToType);
      Thread.Sleep(2000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchButton))).Click();
      Thread.Sleep(2000);
      return new LitresSearchPage(driver, wait);
    }
    
    public UserBookPage GoToUserBookPage()
    {
      // доступ к странице "Мои книги"
      Thread.Sleep(2000);
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookButton))).Click();
      Thread.Sleep(2000);
      return new UserBookPage(driver, wait);
    }

    public LitresGenresPage GoToGenresPage(string genreName)
    {
      // доступ к странице "Жанры"

      string xPathGenre = "//a[text()='"+ genreName + "']"; 
      wait.Until(drv => drv.FindElement(By.XPath(xPathMenuGenres))).Click();
      wait.Until(drv => drv.FindElement(By.XPath(xPathGenre))).Click();
      return new LitresGenresPage(driver, wait);
    }

  }
}
