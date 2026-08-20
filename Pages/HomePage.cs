//Navigate to website
//Open Software menu
//Click Repertoire Management
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TechAssess.Pages;
public class HomePage
{
    private IWebDriver driver;
    private WebDriverWait wait;
    //mmain url
    private const string Url = "https://www.matchingengine.com/";
    
     private readonly By solutionsMenu =
        //for navigation toggle "solutions"
        By.Id("nav-toggle-solutions");
    
    private  By distributionProcessingLink =
        //for distributionProcessingLink
        By.LinkText("Distribution processing");
    private readonly By allowAllCookiesButton =
    //for all Cookies 
    By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");

    public HomePage(IWebDriver driver)
    {   //creating the explicit wait for 5 seconds
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    public void NavigateTo()
    {
        driver.Navigate().GoToUrl(Url);
    }

    public void OpenSolutionsMenu()
    {   //apply wait, this element required for test flow
        var solutions = wait.Until(
            d => d.FindElement(solutionsMenu));

        solutions.Click();
    }

    public void SelectDistributionProcessing()
    {   //apply wait, this element required for test flow
        var distributionProcessing = wait.Until(
            d => d.FindElement(distributionProcessingLink));

        distributionProcessing.Click();
    }
    public void AcceptCookiesIfPresent()
    {   //cookie popup may or may not appear, take allow button only, if it appears we click otherwise empty [] return
        var cookieButtons = driver.FindElements(allowAllCookiesButton);
        if (cookieButtons.Count > 0 && cookieButtons[0].Displayed)
        {
            cookieButtons[0].Click();
        }

    }
    
}