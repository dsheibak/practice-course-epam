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
using SeleniumExtras;


namespace HurtMePlenty
{
  public class GoogleCloudFormPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;

    private string xPathComputerEngine = "//md-pagination-wrapper/md-tab-item[1]";

    private string xPathNumberOfInstances = "//md-input-container/child::input[@ng-model='listingCtrl.computeServer.quantity']";

    private string xPathOperatingSystemList = "//*[@id='select_value_label_82']";
    private string xPathOperatingSystemListTargetElement = "//md-option[@value='free']";

    private string xPathProvisioningModelList = "//*[@id='select_value_label_83']";
    private string xPathProvisioningModelListElement = "//md-option[@value='regular']";

    private string xPathSeriesList = "//*[@id='select_value_label_85']";
    private string xPathSeriesListElement = "//md-option[@id='select_option_201']";

    private string xPathMashineType = "//*[@id='select_value_label_86']";
    private string xPathMashineTypeOption = "//*[@id='select_option_428']";

    private string xPathAddGPUsCheckbox = "//md-checkbox[@aria-label='Add GPUs']";

    private string xPathGPUTypeList = "//md-select[@placeholder='GPU type']";
    private string xPathGPUTypeListElement = "//*[@id='select_option_471']";

    private string xPathNumberofGPUsList = "//*[@id='select_468']";
    private string xPathNumberofGPUsListElement = "//*[@id='select_option_511']";

    private string xPathDataCenterLocationList = "//*[@id='select_123']";
    private string xPathDataCenterLocationListInput = "//*[@id='input_122']";
    private string xPathDataCenterLocationFrankfurtElement = "//*[@id='select_option_228']";
    
    private string xPathCommitedUsageList = "//*[@id='select_130']";
    private string xPathCommitedUsageListElement = "//md-option[@id='select_option_128']";

    private string xPathAddToEstimateButton = "//button[@aria-label='Add to Estimate']";


    public GoogleCloudFormPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(9000));
      wait.Until(drv => drv.FindElement(By.XPath("//iframe[contains(@name,'goog_')]")));
      driverChrome.SwitchTo().Frame(driverChrome.FindElement(By.XPath("//iframe[contains(@name,'goog_')]")));
      driverChrome.SwitchTo().Frame("myFrame");
    }

    public IWebElement FindComputerEngine()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathComputerEngine)));
      return driverChrome.FindElement(By.XPath(xPathComputerEngine));
    }

    public IWebElement FindNumberOfInstances()
    {
      driverChrome.FindElement(By.XPath(xPathNumberOfInstances)).Click();
      return driverChrome.FindElement(By.XPath(xPathNumberOfInstances));
    }

    public IWebElement FindOperatingSystemListElement()
    {
      driverChrome.FindElement(By.XPath(xPathOperatingSystemList)).Click();
      return driverChrome.FindElement(By.XPath(xPathOperatingSystemListTargetElement));
    }

    public IWebElement FindProvisioningModelListElement()
    {
      driverChrome.FindElement(By.XPath(xPathProvisioningModelList)).Click();
      return driverChrome.FindElement(By.XPath(xPathProvisioningModelListElement));
    }

    public IWebElement FindSeriesListElement()
    {
      driverChrome.FindElement(By.XPath(xPathSeriesList)).Click();
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathSeriesListElement)));
    }

    public IWebElement FindMashineTypeOption()
    {
      driverChrome.FindElement(By.XPath(xPathMashineType)).Click();
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathMashineTypeOption)));
    }

    public IWebElement FindAddGPUsCheckbox()
    {
      return driverChrome.FindElement(By.XPath(xPathAddGPUsCheckbox));
    }

    public IWebElement FindGPUTypeListElement()
    {
      driverChrome.FindElement(By.XPath(xPathGPUTypeList)).Click();
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathGPUTypeListElement)));
    }

    public IWebElement FindNumberofGPUsListElement()
    {
      driverChrome.FindElement(By.XPath(xPathNumberofGPUsList)).Click();
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathNumberofGPUsListElement)));
    }
    
    public IWebElement FindDataCenterLocationListInput()
    {
      driverChrome.FindElement(By.XPath(xPathDataCenterLocationList)).Click();
      return driverChrome.FindElement(By.XPath(xPathDataCenterLocationListInput));
    }

    public IWebElement FindDataCenterLocationFrankfurtElement()
    {
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathDataCenterLocationFrankfurtElement)));
    }

    public IWebElement FindCommitedUsageListElement()
    {
      driverChrome.FindElement(By.XPath(xPathCommitedUsageList)).Click();
      return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathCommitedUsageListElement)));
    }

    public IWebElement FindAddToEstimateButton()
    {
      return driverChrome.FindElement(By.XPath(xPathAddToEstimateButton));
    }

    public string GetResultRegion()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//*[@id='compute']/md-list/md-list-item[1]/div"))).Text;
    }

    public string GetResultCommitmentTerm()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//*[@id='compute']/md-list/md-list-item[3]/div"))).Text;
    }

    public string GetResultProvisioningModel()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//*[@id='compute']/md-list/md-list-item[4]/div"))).Text;
    }
    
    public string GetResultInstanceType()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//*[@id='compute']/md-list/md-list-item[5]/div[1]"))).Text;
    }

    public string GetTotalCost()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//*[@id='resultBlock']/md-card/md-card-content/div/div/div/h2/b"))).Text;
    }

  }
}
