# buggy-cars-rating

# Test Approach:

The test approach for this task was to perform manual tests to verify the main functionality offered on the site, including registration, login and voting on the page in the perspective of a user.

This involved testing different elements on the page and identifying any defects on the elements themselves or in the processes related to them, then prioritizing them based on how  these impacted user experience and the functionality of the site as a whole.  The top three were documented as open Issues on this repo.

After this, some automated tests were written using a Selenium Webdriver and XUnit framework to test critical processes or workflows.

Some browser testing was done on Google Chrome, Mozilla Firefox and Microsoft Edge and mobile testing was considered but the only device for this I had on hand was my personal mobile device.

# Bug Documents:

I've added the critical bug documents as Open Issues and labelled as a bug on the repo.  There is 1 closed issue as I viewed that another bug was more critical.  These are:
  1) Car Model pages do not load on Mozilla Firefox 
  2) Password policies are unclear to users and impact user experience
  3) Navigating to Lancia Stratos model page leads to webpage being unresponsive
  
  # Automated Tests:
  
  I've added 3 automated tests:
  * TestNoVotingWhileNotLoggedIn
  * TestSuccessfulRegistration
  * TestVoteWithoutComment

To run these tests, please follow these steps:

**Command Line:**
Prerequisites:
* https://download.visualstudio.microsoft.com/download/pr/cdd7a605-be77-47fe-a8ac-d982c8e5d692/c8abed93d34b110b4f3d3254e56de254/dotnet-runtime-6.0.14-win-x64.exe
* .NET support https://dotnet.microsoft.com/en-us/download, .NET 7.0
* Clone this repo via Github Desktop or download zip and extract into a directory.
* Open the directory in file explorer and type 'cmd' in the navigation field to open directory in command prompt.  Alternatively, open command prompt and type "cd <DIRPATH>"
* Type dotnet test to run tests
  
**Visual Studio:**
  * Clone this repo and open the solution file.
  * In Test Explorer, right click Buggy_Cars_Rating (3) and select "Run"
  
  
