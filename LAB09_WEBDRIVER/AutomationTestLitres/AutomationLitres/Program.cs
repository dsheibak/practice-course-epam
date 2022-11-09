using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using AutomationLitres;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace AutomationLitres
{
  class Program
  {
    public static void Main(string[] args)
    {
      //ChromeDriver driverChrome;
      //ChromeOptions options;
      //LitresHomePage homepage;
      //LitresSearchPage searchpage;
      //LitresBookPage bookpage;
      //UserBookPage userbookpage;

      //options = new ChromeOptions();
      //options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      //driverChrome = new ChromeDriver(options);
      //homepage = new LitresHomePage(driverChrome);

      //homepage.OpenTargetPage();
      //homepage.FindSearchFieldInput().SendKeys("Игра Престолов");
      //searchpage = homepage.GoToSearchResultsPage();

      //bookpage = searchpage.GetHrefToTargetPage();
      //bookpage.FindMarkAsReadButton().Click();

      ////https://www.litres.ru/dzhordzh-r-r-martin-45006/igra-prestolov/

      //if (bookpage.GetButtonMarkAsReadStatus().Equals("ПРОЧИТАНА")) Console.WriteLine("true");

      //userbookpage = bookpage.GoToUserBookPage();
      //userbookpage.FindUserBookListTitle().Click();
      //if(userbookpage.GetBookNameFromUserReadedList()!=null) Console.WriteLine("книга добавлена в список прочтения");

    }
  }
}
