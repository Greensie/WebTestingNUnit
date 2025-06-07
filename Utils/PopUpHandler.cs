using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.ServiceWorker;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebTestingNUnit.Utils
{
    public class PopUpHandler
    {
        public void handleThePasswordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();

            }
            catch (NoSuchElementException)
            {
                TestContext.WriteLine("No PopUp has shown up to the party!");
            }
        }
    }
}
