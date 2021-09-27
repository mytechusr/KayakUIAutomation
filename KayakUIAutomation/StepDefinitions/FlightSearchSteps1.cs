using KayakUIAutomation.Base;
using KayakUIAutomation.Helpers;
using KayakUIAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace KayakUIAutomation.StepDefinitions
{
    [Binding]
    public class FlightSearchSteps
    {
        [BeforeScenario]
        public void Init()
        {
            BrowserHelper.OpenBrowser(BrowserType.FireFox);
        }
        //IWebDriver driver = new FirefoxDriver();
        //private FlightSearchPage flightSearchPage;
        //FlightSearchPage flightSearchPage = new FlightSearchPage(new FirefoxDriver());
        //FlightsListingPage flightsListingPage = new FlightsListingPage();
        //FlightBookingPage flightBookingPage = new FlightBookingPage();

        [Given(@"User navigates to Search Page")]
        public void GivenUserNavigatesToSearchPage()
        {
            //BrowserHelper.OpenBrowser(BrowserType.FireFox);
            NavigationHelper.GoToUrl();
            WaitHelper.WaitForElementVisibility(By.CssSelector(".zEiP-pres-default"), TimeSpan.FromSeconds(20));
            //FlightSearchPage flightSearchPage = new FlightSearchPage();
            //flightSearchPage.WaitForPageToLoad();
            //Assert.IsTrue(WaitHelper.IsElemetPresent())
        }
        
        [When(@"User enters (.), (.), (.) and (.)")]
        public void WhenUserEntersSourceDestinationFromDateAndToDate(string source, string dest, string fromDate, string toDate)
        {
            FlightSearchPage flightSearchPage = new FlightSearchPage();
            //flightSearchPage.WaitForPageToLoad();
            //SearchPage searchPage = new SearchPage();
            flightSearchPage.EnterSource(source);
            //flightSearchPage.EnterSource("New Delhi");
            //flightSearchPage.EnterDestination("Mumbai (BOM)");
            //flightSearchPage.EnterFromDate("Wed 10/11");
            //flightSearchPage.EnterToDate("Wed 17/11");
        }
        
        [When(@"User clicks on Search button")]
        public void WhenUserClicksOnSearchButton()
        {
            SearchPage searchPage = new SearchPage();
            searchPage.ClickSearchButton();

            FlightSearchPage flightSearchPage = new FlightSearchPage();
            //flightSearchPage.WaitForPageToLoad();
            //SearchPage searchPage = new SearchPage();
            Assert.IsTrue(flightSearchPage.IsPopupDisplayed());
        }
        
        [When(@"User clicks on View Deal button")]
        public void WhenUserClicksOnViewDealButton()
        {
            FlightsListingPage listingPage = new FlightsListingPage(); 
            listingPage.ClickViewDeal();
        }
        
        [Then(@"Search Results should be displayed")]
        public void ThenSearchResultsShouldBeDisplayed()
        {
            FlightsListingPage listingPage = new FlightsListingPage();
            bool IsFlightsResultDisplayed = listingPage.VerifySearchResultsListIsDisplayed();
            Assert.IsTrue(IsFlightsResultDisplayed);
            //Assert.(listingPage.VerifyPriceTextIsDisplayed);
        }
        
        [Then(@"Flight details should be displayed")]
        public void ThenFlightDetailsShouldBeDisplayed()
        {
            //FlightsListingPage listingPage = new FlightsListingPage();
            //bool IsViewDealDisplayed = listingPage.VerifySearchResultsListIsDisplayed();
            //Assert.IsFalse(IsViewDealDisplayed);

            //FlightBookingPage bookingPage = new FlightBookingPage();
            //bool IsSourceDestDisplayed = bookingPage.VerifyFlightDetails("New Delhi", "Mumbai");
            //Assert.IsFalse(IsSourceDestDisplayed);
        }

        [AfterScenario]
        public void TearDown()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
        }
    }
}
