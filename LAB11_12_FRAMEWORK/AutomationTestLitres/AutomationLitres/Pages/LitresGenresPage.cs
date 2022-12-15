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
using SeleniumExtras.WaitHelpers;

namespace AutomationLitres.Pages
{
  public class LitresGenresPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;

    private string xPathGenreNovelty = "//span[@class='TabNavigation-module__label_36k4Y' and text()='Новинки']"; // раздел "новинки"
    private string xPathSelectEngButton = "//*[@id='__next']/div[1]/div[2]/div/div/div[1]/div[8]/div[2]/div[1]/div[2]/div/label/div"; // кнопка "английский" в меню фильтра
    private string xPathSelectAudioButton = "//*[@id='__next']/div[1]/div[2]/div/div/div[1]/div[7]/div[3]/div/label/div"; //- кнопка "аудио" в меню фильтра
    
    private string xPathEngFilter = "//div[text()='Английский']"; // пометка "английский" с крестиком
    private string xPathAudioFilter = "//div[text()='Аудио']"; // пометка "аудио" с крестиком

    public LitresGenresPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public IWebElement GetGenreNoveltyOnEng()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathGenreNovelty))).Click();
      Thread.Sleep(3000);
      return wait.Until(drv => drv.FindElement(By.XPath(xPathSelectEngButton))); 
    } 

    public IWebElement CheckGenresOnLanguageFilter()
    {
      Thread.Sleep(3000);
      return wait.Until(drv => drv.FindElement(By.XPath(xPathEngFilter)));
    }

    public IWebElement GetGenrePopularAudio()
    {
      Thread.Sleep(3000);
      return wait.Until(drv => drv.FindElement(By.XPath(xPathSelectAudioButton)));
    }

    public IWebElement CheckGenresOnAudioFilter()
    {
      Thread.Sleep(3000);
      return wait.Until(drv => drv.FindElement(By.XPath(xPathAudioFilter)));
    }

  }
}
