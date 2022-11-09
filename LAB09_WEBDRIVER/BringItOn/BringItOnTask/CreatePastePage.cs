using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;


namespace BringItOn
{
  public class CreatePastePage
  {
    private IWebDriver driverChrome;
    private string targetUrl = "https://pastebin.com";

    private string idInputCodeField = "postform-text";

    private string idProgrammingLanguageList = "select2-postform-format-container";
    private string xPathProgrammingLanguageListItem = "//li[text()='Batch']";

    private string idPostExpirationList = "select2-postform-expiration-container";
    private string xPathPostExpirationListItem = "//li[text()='10 Minutes']";

    private string idPostTitleField = "postform-name";

    private string xPathButtonCreatePost = "//button[@class='btn -big' and @type='submit']";

    public CreatePastePage(IWebDriver driver)
    {
      driverChrome = driver;
    }

    public void OpenTargetPage()
    {
      driverChrome.Navigate().GoToUrl(targetUrl);
    }

    public IWebElement FindCodeInputFiled()
    {
      return driverChrome.FindElement(By.Id(idInputCodeField));
    }

    public IWebElement FindProgrammingLanguageItemInList()
    {
      driverChrome.FindElement(By.Id(idProgrammingLanguageList)).Click();
      return driverChrome.FindElement(By.XPath(xPathProgrammingLanguageListItem));
    }

    public IWebElement FindPostExpirationItemInList()
    {
      driverChrome.FindElement(By.Id(idPostExpirationList)).Click();
      return driverChrome.FindElement(By.XPath(xPathPostExpirationListItem));
    }

    public IWebElement FindPostTitleField()
    {
      return driverChrome.FindElement(By.Id(idPostTitleField));
    }

    public PublishPastePage CreatePost()
    {
      driverChrome.FindElement(By.XPath(xPathButtonCreatePost)).Click();
      return new PublishPastePage(driverChrome);
    }

  }
}
