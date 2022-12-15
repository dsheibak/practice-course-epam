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
using AutomationLitres.Steps;
using AutomationLitres.Model;
using AutomationLitres.Service;
using System.IO;

using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;

namespace LitresTests.Tests
{
  [TestFixture]
  public class AutoTests
  {
    public ExtentReports extent;
    public ExtentTest test;

    private Steps steps = new Steps();
    User testUser = UserCreator.WithCredentials();

    private string expectedSubscribeButtonStatus = "Вы подписаны";
    public string expectedMarkedAsReadBookStatus = "ПРОЧИТАНА";

    [OneTimeSetUp]
    public void StartReport()
    {
      steps.InitBrowser();

      string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
      string actualPath = path.Substring(0, path.LastIndexOf("bin"));
      string projectPath = new Uri(actualPath).LocalPath;
      string reportPath = projectPath + "Reports\\MyOwnReport.html";

      extent = new ExtentReports(reportPath, true);
      extent
      .AddSystemInfo("Host Name", "User-PC")
      .AddSystemInfo("Environment", "QA")
      .AddSystemInfo("User Name", "Daria Sheibak");
      extent.LoadConfig(projectPath + "extent-config.xml");
    }
    
    [TearDown]
    public void GetResult()
    {
      var status = TestContext.CurrentContext.Result.Outcome.Status;
      var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
      var errorMessage = TestContext.CurrentContext.Result.Message;

      if (status == TestStatus.Failed)
      {
        test.Log(LogStatus.Fail, stackTrace + errorMessage);
      }
      extent.EndTest(test);
    }
    [OneTimeTearDown]
    public void EndReport()
    {
      steps.CloseBrowser();
      extent.Flush();
      extent.Close();
    }

    [Test] //9 тест: подписка на новинки популярного автора
    public void UserCanBeCorrectlySubscribedToPopularAuthor()
    {
      test = extent.StartTest("UserCanBeCorrectlySubscribedToPopularAuthor");

      steps.LoginLitres()
           .GoToPopularAuthorsPage()
           .FindPopularAuthor()
           .FindSubscribeButton().Click();
      Thread.Sleep(3000);
      Assert.True(steps.GetSubscribeAutorButtonStatus().Equals(expectedSubscribeButtonStatus));

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //3 тест: добавление выбранной книги в корзину
    public void BookCanBeCorrectlyAddedToBasket()
    {
      test = extent.StartTest("BookCanBeCorrectlyAddedToBasket");

      steps.LoginLitres()
           .GoToSearchResultsPage("Игра престолов")
           .GetHrefToTargetPage()
           .FindAddToBasketButton().Click();
      Thread.Sleep(3000);
      Assert.True(steps.CheckUserBasketOnBookPresence() != null);

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //2 тест: добавление книги в список прочитанных книг
    public void UnreadedBookCanBeCorrectlyMarkedAsReadedByButtonClick()
    {
      test = extent.StartTest("UnreadedBookCanBeCorrectlyMarkedAsReadedByButtonClick");

      steps.LoginLitres()
        .GoToSearchResultsPage("Игра престолов")
        .GetHrefToTargetPage()
        .FindMarkAsReadButton().Click();
      Thread.Sleep(3000);
      Assert.True(steps.GetButtonMarkAsReadStatus().Equals(expectedMarkedAsReadBookStatus)
        && steps.GetBookNameFromUserReadedList() != null);

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //10 тест: удаление из корзины пользователя выбранной к покупке книги
    public void AddedToBasketBookCanBeCorrectlyRemovedFromBasket()
    {
      test = extent.StartTest("AddedToBasketBookCanBeCorrectlyRemovedFromBasket");

      steps.LoginLitres(testUser)
        .GoToSearchResultsPage("Игра престолов")
        .GetHrefToTargetPage()
        .FindAddToBasketButton().Click();
      Thread.Sleep(3000);
      Assert.Throws<NoSuchElementException>(() => steps.FindRemovedFromBasketBookInBasket());

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //4 тест: создание пользовательского списка книг
    public void UserListBookCanBeCreated()
    {
      test = extent.StartTest("UserListBookCanBeCreated");

      steps.LoginLitres()
        .GoToUserBookPage()
        .CreateUserBookList("Книги на зиму")
        .Click();
      Thread.Sleep(3000);
      Assert.DoesNotThrow(() => steps.GetBookListName("Книги на зиму"));

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //8 тест: поиск книжных новинок жанра на английском
    public void SeriesOfSelectedGenreCanBeFound()
    {
      test = extent.StartTest("SeriesOfSelectedGenreCanBeFound");

      steps.LoginLitres()
           .GoToGenresPage("О бизнесе популярно")
           .GetGenreNoveltyOnEng().Click();
      Thread.Sleep(3000);
      Assert.DoesNotThrow(() => steps.GetGenresLang());

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //6 тест: получение серии книг найденного литературного жанра
    public void SelectedGenreBookSeriesCanBeFound()
    {
      test = extent.StartTest("SelectedGenreBookSeriesCanBeFound");

      steps.LoginLitres()
           .GoToSearchResultsPage("Психология")
           .GetHrefToSeriesPage();
      Thread.Sleep(3000);
      Assert.True(steps.IsPageSeriesContainsSeriesTitle());

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //5 тест: добавление книги в создаваемый пользователем список книг
    public void BookCanBeAddedToCreatedUserList()
    {
      test = extent.StartTest("BookCanBeAddedToCreatedUserList");

      Thread.Sleep(3000);

      steps.LoginLitres()
           .GoToSearchResultsPage("Игра престолов")
           .GetHrefToTargetPage()
           .CreateUserBookList("Книжные рекомендации").Click();

      Thread.Sleep(3000);
      Assert.DoesNotThrow(() => steps.GetBookListNameFromAllLists("Книжные рекомендации"));

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

    [Test] //7 тест: получение популярных аудиокниг жанра
    public void SelectedGenreBookPopularInAudioCanBeFound()
    {
      test = extent.StartTest("SelectedGenreBookPopularInAudioCanBeFound");

      steps.LoginLitres()
           .GoToGenresPage("О бизнесе популярно")
           .GetGenrePopularAudio().Click();
      Thread.Sleep(3000);
      Assert.DoesNotThrow(() => steps.GetGenresAudioStatus());

      test.Log(LogStatus.Pass, "Assert Pass as condition is True");
    }

  }
}
