using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using HurtMePlenty;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace CorrectFormDataAndCalcVMPriceTests.Tests
{
  [TestFixture]
  public class CorrectFormDataAndCalcVMPriceTest
  {
    public string numberOfInstances = "4";
    public string locationCity = "Frankfurt";

    public string expectedLocationCity = "Frankfurt";
    public string expectedCommitmentTerm = "1 Year";
    public string expectedProvisioningModel = "Regular";
    public string expectedInstanceType = "n1-standard-8";
    public string expectedTotalCost = "USD 3,843.12";


    public ChromeDriver driverChrome;
    public ChromeOptions options;
    public GoogleCloudeHomePage googleCloudHomePage;
    public GoogleCloudSearchPage googleCloudSearchPage;
    public GoogleCloudFormPage googleCloudFormPage;


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
      googleCloudFormPage.FindAddToEstimateButton().Click();

    }

    [Test]
    public void SelectedRegionMatchesRegionOnEstimateForm()
    {
      Assert.True(googleCloudFormPage.GetResultRegion().Contains(expectedLocationCity));
    }

    [Test]
    public void SelectedCommitmentTermMatchesTermOnEstimateForm()
    {
      Assert.True(googleCloudFormPage.GetResultCommitmentTerm().Contains(expectedCommitmentTerm));
    }

    [Test]
    public void SelectedProvisioninModelMatchesModelOnEstimateForm()
    {
      Assert.True(googleCloudFormPage.GetResultProvisioningModel().Contains(expectedProvisioningModel));
    }

    [Test]
    public void SelectedInstanceTypeMatchesInstanceTypeOnEstimateForm()
    {
      Assert.True(googleCloudFormPage.GetResultInstanceType().Contains(expectedInstanceType));
    }

    [Test]
    public void ResultTotalCostMatchesTotalCostInManualTesting()
    {
      Assert.True(googleCloudFormPage.GetTotalCost().Contains(expectedTotalCost));
    }

    [OneTimeTearDown]
    public void close_Browser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }


  }
}
