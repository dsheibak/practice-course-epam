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
using AutomationLitres.Pages;
using AutomationLitres.Driver;
using System.IO;
using AutomationLitres.Model;

namespace AutomationLitres.Steps
{
  public class Steps
  {
    private IWebDriver driver;
    private WebDriverWait wait;
    private static ChromeOptions driverOptions;

    public void InitBrowser()
    {
      driverOptions = new ChromeOptions();
      driverOptions.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      driverOptions.AddArguments("--window-size=1920,1080");
      //driverOptions.AddArguments("--headless");
      driver = DriverSingleton.GetDriver(driverOptions);
      DriverSingleton.SetDriverOptions();
      wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4000));
    }

    public void CloseBrowser()
    {
      Driver.DriverSingleton.CloseDriver();
    }

    public LitresHomePage LoginLitres(User testUser)
    {
      LoginPage loginPage = new LoginPage(driver, wait);
      Thread.Sleep(3000);
      loginPage.OpenPage();
      Thread.Sleep(3000);
      loginPage.Login(testUser.GetEmail(), testUser.GetPassword());
      Thread.Sleep(3000);
      return new LitresHomePage(driver, wait);
    }

    public LitresHomePage LoginLitres()
    {
      LoginPage loginPage = new LoginPage(driver, wait);
      loginPage.OpenPage();
      return new LitresHomePage(driver, wait);
    }

    public string GetSubscribeAutorButtonStatus()
    {
      SelectedPopularAuthorPage selectedPopularAuthorPage = new SelectedPopularAuthorPage(driver, wait);
      return selectedPopularAuthorPage.GetSubscribeButtonStatus();
    }

    public object CheckUserBasketOnBookPresence()
    {
      LitresBookPage litresBookPage = new LitresBookPage(driver, wait);
      return litresBookPage.GoToUserBookPage().GetBookNameFromBasket();
    }

    public string GetButtonMarkAsReadStatus()
    {
      LitresBookPage litresBookPage = new LitresBookPage(driver, wait);
      return litresBookPage.GetButtonMarkAsReadStatus();
    }

    public object GetBookNameFromUserReadedList()
    {
      LitresBookPage litresBookPage = new LitresBookPage(driver, wait);
      return litresBookPage.GoToUserBookPage().GetBookNameFromUserReadedList();
    }

    public object FindRemovedFromBasketBookInBasket()
    {
      LitresBookPage litresBookPage = new LitresBookPage(driver, wait);
      return litresBookPage.GoToUserBookPage().RemoveBookFromBasket();
    }

    public object GetBookListName(string listName)
    {
      UserBookPage userBookPage = new UserBookPage(driver, wait);
      return userBookPage.CheckUserListsOnAddedListPresence(listName);
    }

    public object GetBookListNameFromAllLists(string listName)
    {
      LitresBookPage litresBookPage = new LitresBookPage(driver, wait);
      return litresBookPage.GoToUserBookPage().CheckUserListsListPresenceByHrefs(listName);
    }

    public object GetGenresLang()
    {
      LitresGenresPage genresPage = new LitresGenresPage(driver, wait);
      return genresPage.CheckGenresOnLanguageFilter();
    }

    public bool IsPageSeriesContainsSeriesTitle()
    {
      LitresSeriesPage seriesPage = new LitresSeriesPage(driver, wait);
      return seriesPage.FindTitlesOnSeriesPage();
    }

    public object GetGenresAudioStatus()
    {
      LitresGenresPage genresPage = new LitresGenresPage(driver, wait);
      return genresPage.CheckGenresOnAudioFilter();
    }

  }
}
