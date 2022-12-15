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

namespace AutomationLitres.Driver
{
  public class DriverSingleton
  {
      private static IWebDriver driver;

      private DriverSingleton() { }

      public static IWebDriver GetDriver(ChromeOptions driverOptions)
      {
          if (driver == null)
          {
              driver = new ChromeDriver(driverOptions);
          }

          return driver;
      }

    public static void SetDriverOptions()
    {
        driver.Manage().Window.Maximize();
    }

    public static void CloseDriver()
    {
        driver.Close();
        driver.Quit();
        driver = null;
    }
  }
}
