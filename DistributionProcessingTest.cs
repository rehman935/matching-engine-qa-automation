using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechAssess.Pages;

namespace TechAssess;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {   //driver object for chrome only now
        driver = new ChromeDriver();
        //mx window size
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void DistributionProcessing_AllInOneSolutionForScale_ShouldBeVisible()
    {   //driver instance pass to both class/POMs
        var homePage = new HomePage(driver);
        var distributionProcessingPage = new DistributionProcessingPage(driver);
        //Navigate to the homepage,  scroll to the distribution processing section, and get the features
        homePage.NavigateTo();
        //accept cookies
        homePage.AcceptCookiesIfPresent();
        
        //opening the solutions menu 
        homePage.OpenSolutionsMenu();
        //select distribution processing
        homePage.SelectDistributionProcessing();
        //scroll to the distribution processing section
        distributionProcessingPage.ScrollToDistributionProcessing();
        //optional: 
        var features = distributionProcessingPage.GetDistributionProcessingFeatures();
        //Print in console
        foreach (var feature in features)
        {
            Console.WriteLine(feature);
        }
        //asserting the distribution processing features are visible or not
        Assert.That(
            distributionProcessingPage.IsAllinOneSolutionForScalesVisible(),
            Is.True,
            "Distribution processing section is not visible.");
    }

    [TearDown]
    public void TearDown()
    {
        //quit the browser
        driver.Quit();
        //cleans up the WebDriver object's resources.
        driver.Dispose();
    }
}