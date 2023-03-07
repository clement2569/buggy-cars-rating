using OpenQA.Selenium;

namespace Buggy_Cars_Rating
{
    internal class Utilities
    {
        //Helper functions that are shared across the test cases.


        //Generates new login name by adding a number based on entries in text file.    
        public static string GenerateNewLogin(string _username)
        {
            string path = "./Automated_Users_List.txt";
            var textLines = File.ReadAllLines(path);
            string loginName = _username + textLines.Count().ToString();
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine(loginName);
            }
            return loginName;
        }

        //Registers a new user by filling the forms with provided login and password.  
        public static void RegisterNewUser(IWebDriver _driver, string loginName, string _password)
        {
            _driver.FindElement(By.Id("username")).SendKeys(loginName);
            _driver.FindElement(By.Id("firstName")).SendKeys("First");
            _driver.FindElement(By.Id("lastName")).SendKeys("Last");

            _driver.FindElement(By.Id("password")).SendKeys(_password);
            _driver.FindElement(By.Id("confirmPassword")).SendKeys(_password);

            
            _driver.FindElement(By.XPath("//button[@type='submit' and text()='Register']")).Click();
            Thread.Sleep(3000);
        }

        //Login to the page with provided login name and password.
        public static void Login(IWebDriver _driver,string loginName, string password)
        {
            _driver.FindElement(By.Name("login")).SendKeys(loginName);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _driver.FindElement(By.XPath("//button[@type='submit' and text()='Login']")).Click();
            Thread.Sleep(2000);
        }
    }
}
