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
using Hardcore;
using System.IO;

namespace CorrectFormDataAndCalcVMPriceTests.Tests
{
  [TestFixture]
  public class CorrectFormDataAndCalcVMPriceTest
  {
    public string numberOfInstances = "4";
    public string locationCity = "Frankfurt";

    public string totalCostFromVMForm = "";
    public string totalCostFromEmail = "";

    public string emailToSendVMReport = "";

    public ChromeDriver driverChrome;
    public ChromeOptions options;
    public GoogleCloudeHomePage googleCloudHomePage;
    public GoogleCloudSearchPage googleCloudSearchPage;
    public GoogleCloudFormPage googleCloudFormPage;
    public GenerateEmailPage generateEmailPage;


    [OneTimeSetUp]
    public void InitializeContext()
    {
      options = new ChromeOptions();
      options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      driverChrome = new ChromeDriver(options);
      googleCloudHomePage = new GoogleCloudeHomePage(driverChrome);

      googleCloudHomePage.OpenTargetPage();
      googleCloudHomePage.FindSearchButton().Click();
      googleCloudHomePage.SearchFormPage().SendKeys("Google Cloud Platform Pricing Calculator");

      googleCloudSearchPage = googleCloudHomePage.GetSearchResultPage();
      googleCloudFormPage = googleCloudSearchPage.GetHrefToTargetPage();

      googleCloudFormPage.FindComputerEngine().Click();
      googleCloudFormPage.FindNumberOfInstances().SendKeys(numberOfInstances);
      googleCloudFormPage.FindOperatingSystemListElement().Click();
      googleCloudFormPage.FindOperatingSystemListElement().Click();
      googleCloudFormPage.FindProvisioningModelListElement().Click();
      googleCloudFormPage.FindSeriesListElement().Click();
      googleCloudFormPage.FindMashineTypeOption().Click();
      googleCloudFormPage.FindDataCenterLocationListInput().SendKeys(locationCity);
      googleCloudFormPage.FindDataCenterLocationFrankfurtElement().Click();

      googleCloudFormPage.FindAddGPUsCheckbox().Click();
      googleCloudFormPage.FindGPUTypeListElement().Click();
      googleCloudFormPage.FindNumberofGPUsListElement().Click();

      googleCloudFormPage.FindCommitedUsageListElement().Click();
      googleCloudFormPage.FindSSDListElement().Click();

      googleCloudFormPage.FindAddToEstimateButton().Click();

      generateEmailPage = googleCloudFormPage.OpenGenerateEmailSitePage();
      generateEmailPage.FindGereyageEmailButton().Click();

      emailToSendVMReport = generateEmailPage.GetGeneratedEmail();
      generateEmailPage.SwitchBackToVMCalculator();

      googleCloudFormPage.SwitchToMainForm();
      googleCloudFormPage.FindSendEmailButton().Click();
      googleCloudFormPage.GetEmailInputField().SendKeys(emailToSendVMReport);
      googleCloudFormPage.FindSendReportToEmailButton().Click();
      googleCloudFormPage.SwitchToEmailPageGenerator();

      generateEmailPage.FindCheckInboxButton().Click();
    }

    [Test]
    public void ResultTotalCostMatchesTotalCostInManualTesting()
    {
      totalCostFromEmail = generateEmailPage.GetEmailTotalCost();

      generateEmailPage.SwitchBackToVMCalculator();
      googleCloudFormPage.SwitchToMainForm();
      totalCostFromVMForm = googleCloudFormPage.GetTotalCost();

      Assert.True(totalCostFromVMForm.Contains(totalCostFromEmail));
    }

    [OneTimeTearDown]
    public void close_Browser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }


  }
}
