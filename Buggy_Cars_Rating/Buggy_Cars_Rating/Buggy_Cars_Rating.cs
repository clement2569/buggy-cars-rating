using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Buggy_Cars_Rating
{
    public class Buggy_Cars_Rating : IDisposable
    {
        private IWebDriver _driver;
        private readonly string _homeUrl, _alfaRomeoModelUrl, _registerUrl, _password;
        private string _username;
        private Utilities _utils;


        public Buggy_Cars_Rating() 
        {
            _utils = new Utilities();

            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            //quick navigation urls
            _homeUrl = "https://buggy.justtestit.org";
            _alfaRomeoModelUrl = _homeUrl+"/model/c4u1mqnarscc72is00ng%7Cc4u1mqnarscc72is00sg";
            _registerUrl = _homeUrl + "/register";
            
            //credentials

            _username = "bcr_automated_user_";  //prefix of automated user
            _password = "Testing123!";
            
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
        

        //Test that user is unable to vote while not logged in due via vote button.
        [Fact]
        public void TestNoVotingWhileNotLoggedIn()
        {
            _driver.Navigate().GoToUrl(_alfaRomeoModelUrl);
            Thread.Sleep(3000);
            var loginRequiredMessage = _driver.FindElement(By.XPath("//p[@class='card-text']")).Text;

            //verify no vote button
            Assert.Empty(_driver.FindElements(By.XPath("//button[@class='btn btn-success' and text()='Vote!']")));
            //verify no comment box
            Assert.Empty(_driver.FindElements(By.XPath("//textarea[@id='comment']")));
            //verify login requirement message
            Assert.Equal("You need to be logged in to vote.", loginRequiredMessage);
        }

        //Test user can successfully register (and proceed to login as verification).
        [Fact]
        public void TestSuccessfulRegistration()
        {
            //register a new account
            _driver.Navigate().GoToUrl(_registerUrl);
            Thread.Sleep(3000);

            //Generate a new login name
            string loginName = Utilities.GenerateNewLogin(_username);

            //Register using generated login name and predetermined valid password.
            Utilities.RegisterNewUser(_driver, loginName,_password);

            var registrationSuccess = _driver.FindElement(By.XPath("//div[@class='result alert alert-success']"));

            //verify registration success popup message and check if displayed
            Assert.Equal("Registration is successful", registrationSuccess.Text);
            Assert.True(registrationSuccess.Displayed);

            //login
            Utilities.Login(_driver, loginName, _password);

            var loginGreeting = _driver.FindElement(By.XPath("//span[@class='nav-link disabled']"));

            //verify login greeting message and check if displayed
            Assert.Equal("Hi, First", loginGreeting.Text);
            Assert.True(loginGreeting.Displayed);
        }

        //Test that a logged in user can vote without comment and verify that the vote count has incremented by 1
        [Fact]
        public void TestVoteWithoutComment()
        
        {
            _driver.Navigate().GoToUrl(_registerUrl);
            Thread.Sleep(3000);

            //Generate a new login name
            string loginName = Utilities.GenerateNewLogin(_username);

            //Register using generated login name and predetermined valid password.
            Utilities.RegisterNewUser(_driver, loginName, _password);

            _driver.Navigate().GoToUrl(_alfaRomeoModelUrl);

            //login
            Utilities.Login(_driver, loginName, _password);
            Thread.Sleep(3000);

            //get the vote count before pressing vote
            int beforeVoteCount = Int32.Parse(_driver.FindElement(By.XPath("//h4//strong")).Text);
            

            _driver.FindElement(By.XPath("//button[@class='btn btn-success' and text()='Vote!']")).Click();
            Thread.Sleep(3000);

            int afterVoteCount = Int32.Parse(_driver.FindElement(By.XPath("//h4//strong")).Text);     
            var voteThank = _driver.FindElement(By.XPath("//div//p[@class='card-text']"));

            //verify the vote count is incremented by 1 after voting.
            Assert.Equal(afterVoteCount, beforeVoteCount + 1);
            //verify thank you message on voting.
            Assert.Equal("Thank you for your vote!", voteThank.Text);
            Assert.True(voteThank.Displayed);
        }
    }
}