# QA Automation Technical Assessment

This project contains the automated UI test developed for the QA Automation Technical Assessment.

The solution uses **Selenium WebDriver with C# and NUnit** and follows the **Page Object Model (POM)** design pattern.

## Automated Scenario

The automated test performs the following steps:

1. Launch Google Chrome.
2. Navigate to the Matching Engine website.
3. Accept the cookie banner if it is displayed.
4. Open the **Solutions** navigation menu.
5. Select **Distribution processing**.
6. Navigate to the **All-in-one solution for scale** section.
7. Retrieve the feature titles displayed within the section.
8. Validate the section and its expected content.
9. Close the browser after test execution.

## Technologies Used

- C#
- .NET
- Selenium WebDriver
- NUnit
- Google Chrome
- Page Object Model (POM)

## Project Structure

```text
TechAssess/
│
├── Pages/
│   ├── HomePage.cs
│   └── Distribution_processing.cs
│
├── DistributionProcessingTest.cs
├── TechAssess.csproj
├── README.md
└── .gitignore
```

### HomePage

Contains the homepage locators and interactions, including:

- Navigation to the Matching Engine website
- Optional cookie-banner handling
- Opening the **Solutions** navigation menu
- Selecting **Distribution processing**

### DistributionProcessingPage

Contains the page-specific locators and interactions for the Distribution Processing page, including:

- Locating the **All-in-one solution for scale** section
- Scrolling the section into view
- Retrieving the displayed feature titles
- Checking section visibility

### DistributionProcessingTest

Contains the NUnit test scenario, including:

- WebDriver setup
- Page Object initialization
- Test execution
- Assertions
- Browser cleanup

## Synchronisation

The automation uses Selenium `WebDriverWait` explicit waits for required dynamic elements instead of relying on fixed delays.

This allows the test to continue as soon as the required element becomes available while still providing a maximum timeout if the element cannot be found.

## Cookie Handling

The cookie banner is handled conditionally because it may not appear on every test execution.

`FindElements()` is used to check whether the **Allow all** button is present. If the cookie banner is not displayed, an empty collection is returned and the test continues without throwing a `NoSuchElementException`.

## Locator Strategy

The automation uses simple and maintainable Selenium locators based on the available HTML structure.

Where possible, stable locators such as `Id` and `LinkText` are preferred. XPath is used where necessary to identify specific sections based on their visible content and DOM structure.

## Running the Test

### Prerequisites

Ensure the following are installed:

- .NET SDK
- Google Chrome
- Git

### Restore Dependencies

```bash
dotnet restore
```

### Run the Test

```bash
dotnet test
```

For detailed console output:

```bash
dotnet test --logger "console;verbosity=detailed"
```

## Design Approach

The solution follows the **Page Object Model** to separate page-specific Selenium interactions from the test scenario.

The implementation is intentionally lightweight for the scope of the assessment while maintaining clear separation of responsibilities, reusable page actions, explicit synchronisation, conditional cookie handling, and readable test execution.