using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper FillNewContact(ContactData account)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(account.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(account.Lastname);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
    }
}
