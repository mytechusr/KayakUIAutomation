using KayakUIAutomation.Base;
using KayakUIAutomation.Config;
using KayakUIAutomation.Helpers;
using KayakUIAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace KayakUIAutomation.StepDefinitions
{
    [Binding]
    public class FlightSearchSteps
    {
        [BeforeScenario]
        public void Init()
        {
            BrowserHelper.OpenBrowser(ConfigReader.browser);
        }

        [Given(@"User navigates to Search Page")]
        public void GivenUserNavigatesToSearchPage()
        {
            NavigationHelper.GoToUrl();
            WaitHelper.WaitForPageToLoad();
        }

        [When(@"User enters ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void WhenUserEntersAnd(string source, string dest, string fromDate, string toDate)
        {
            FlightSearchPage flightSearchPage = new FlightSearchPage();
            flightSearchPage.EnterSource(source);
            flightSearchPage.EnterDestination(dest);
            flightSearchPage.EnterFromDate(fromDate);
            flightSearchPage.EnterToDate(toDate);
        }

        [When(@"User clicks on Search button")]
        public void WhenUserClicksOnSearchButton()
        {
            FlightSearchPage flightSearchPage = new FlightSearchPage();
            flightSearchPage.ClickSearchButton();
        }

        [When(@"User clicks on View Deal button")]
        public void WhenUserClicksOnViewDealButton()
        {
            FlightsListingPage listingPage = new FlightsListingPage();
            listingPage.ClickViewDeal();
        }

        [When(@"User does not enter Destination")]
        public void WhenUserDoesNotEnterDestination()
        {
            FlightSearchPage flightSearchPage = new FlightSearchPage();
            flightSearchPage.ClearDestination();
        }

        [Then(@"Search Results should be displayed")]
        public void ThenSearchResultsShouldBeDisplayed()
        {
            FlightsListingPage listingPage = new FlightsListingPage();
            bool IsFlightsResultDisplayed = listingPage.VerifySearchResultsListIsDisplayed();
            Assert.IsTrue(IsFlightsResultDisplayed);
        }

        [Then(@"Flight details should be displayed")]
        public void ThenFlightDetailsShouldBeDisplayed()
        {
            FlightDetailsPage detailsPage = new FlightDetailsPage();
            Assert.IsFalse(detailsPage.IsPriceDisplayed());
            // Note: More assertions can be added here
        }

        [Then(@"User gets error message that airport is empty")]
        public void ThenUserGetsErrorMessageThatAirportIsEmpty()
        {
            FlightSearchPage flightSearchPage = new FlightSearchPage();
            Assert.IsTrue(flightSearchPage.IsPopupDisplayed());
        }

        [AfterScenario]
        public void TearDown()
        {
            if (DriverContext.Driver != null)
            {
                DriverContext.Driver.Close();
                DriverContext.Driver.Quit();
            }
        }
    }
}
