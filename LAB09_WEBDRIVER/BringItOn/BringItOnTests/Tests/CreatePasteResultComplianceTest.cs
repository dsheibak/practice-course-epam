// Открыть https://pastebin.com  или аналогичный сервис в любом браузере
// Создать New Paste со следующими деталями:
// Код: git config --global user.name  "New Sheriff in Town" 
// git reset $(git commit-tree HEAD^{ tree} -m "Legacy code")
// git push origin master --force
// Syntax Highlighting: "Bash"
// Paste Expiration: "10 Minutes"
// Paste Name / Title: "how to gain dominance among developers"
// Сохранить paste и проверить следующее:
// Заголовок страницы браузера соответствует Paste Name / Title
// Синтаксис подвечен для bash
// Проверить что код соответствует введенному в пункте 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using BringItOn;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CreatePasteResultDataComplianceTests.Tests
{
  [TestFixture]
  public class CreatePasteResultComplianceTest
  {

    public string pasteTitle = "how to gain dominance among developers", pasteProgrammingLanguage = "Batch";
    public List<string> pasteCodeList = new List<string>();
    public string pasteCode = "git config--global user.name \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{ tree} -m \"Legacy code\")\ngit push origin master --force";
    //public string pasteCode = "DASHA";

    public ChromeDriver driverChrome;
    public ChromeOptions options;
    public CreatePastePage createPastPage;
    public PublishPastePage publishPastPage;

    [OneTimeSetUp]
    public void InitializeContext()
    {
      options = new ChromeOptions();
      options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      driverChrome = new ChromeDriver(options);
      createPastPage = new CreatePastePage(driverChrome);

      pasteCodeList.Add("git config--global user.name \"New Sheriff in Town\"");
      pasteCodeList.Add("git reset $(git commit-tree HEAD^{ tree} -m \"Legacy code\")");
      pasteCodeList.Add("git push origin master --force");

      createPastPage.OpenTargetPage();
      createPastPage.FindCodeInputFiled().SendKeys(pasteCode);
      createPastPage.FindPostTitleField().SendKeys(pasteTitle);
      createPastPage.FindPostExpirationItemInList().Click();
      createPastPage.FindProgrammingLanguageItemInList().Click();
      publishPastPage = createPastPage.CreatePost();
    }
 
    [Test]
    public void SelectedProgrammingLanguageTypeIsHighlightedOnResultPage()
    {
      Assert.True(publishPastPage.GetSelectedProgrammingLanguage().Equals(pasteProgrammingLanguage));
    }
    [Test]
    public void PageTitleMatchesEnteredPastTitleOnResultPage()
    {
      Assert.True(publishPastPage.GetPageTitle().Equals(pasteTitle));
    }
    [Test]
    public void PastCodeMatchesEnteredPastCodeOnResultPage()
    {
      Assert.True(publishPastPage.GetPastCode().ElementAt(0).Equals(pasteCodeList.ElementAt(0)) &&
      publishPastPage.GetPastCode().ElementAt(1).Equals(pasteCodeList.ElementAt(1)) &&
      publishPastPage.GetPastCode().ElementAt(2).Equals(pasteCodeList.ElementAt(2))
        );
    }

    [OneTimeTearDown]
    public void close_Browser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }


  }
}
