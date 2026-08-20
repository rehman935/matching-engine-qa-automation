using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TechAssess.Pages;

public class DistributionProcessingPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    private By distributionProcessingHeading =
        //used normalize-space() to make the XPath less sensitive to extra whitespace
        By.XPath("//h2[normalize-space()='All-in-one solution for scale']");
     private By distributionProcessingSection =
        //finding a section and contains an <h2> with the text “Distribution processing, and filter by "Distribution processing"
        By.XPath("//div[contains(@class,'Section_inner')][.//h2[normalize-space()='All-in-one solution for scale']]");

    public DistributionProcessingPage(IWebDriver driver)
    {
        this.driver = driver;
        //creating the explicit wait for 5 seconds
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    public void ScrollToDistributionProcessing()
    {   //I waited until "distributionProcessingHeading = Distribution processing" found
        var distributionProcessing = wait.Until(
            d => d.FindElement(distributionProcessingHeading));
        //here i swithc driver to javascript executor to Scroll
        //IJavaScriptExecutor allows Selenium to execute JavaScript inside that browser.
        ((IJavaScriptExecutor)driver)
            .ExecuteScript(
                //Scroll until this element comes into view. till cente
                //distributionProcessing is passing to arguments[0]
                "arguments[0].scrollIntoView({block:'start'});", distributionProcessing);
    }
    public bool IsAllinOneSolutionForScalesVisible()
    {   //apply wait, this element required for test flow
        var distributionProcessing = wait.Until(
            d => d.FindElement(distributionProcessingSection));
        return distributionProcessing.Displayed;
    }
    
    public List<string> GetDistributionProcessingFeatures()
    {
        //finding only software Features Section
        var section = driver.FindElement(distributionProcessingSection);
        //filter from section all the h5 headings
        var allSolutionElements = section.FindElements(By.TagName("h5"));
        //empty list 
        List<string> solution = new List<string>();

        foreach (var element in allSolutionElements)
        {
        //append all the feture heading in listof array
        solution.Add(element.Text);
        }

    return solution;
    }
}