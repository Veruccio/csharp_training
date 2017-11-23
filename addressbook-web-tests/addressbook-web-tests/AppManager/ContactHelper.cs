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

        public ContactHelper CreateNewContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();

            InitNewContact();
            FillNewContact(contact);
            SubmitNewContact();
            return this;
        }
      

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            EditContact(v);
            FillNewContact(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            RemoveContact();
            return this;
        }


        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
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

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }


        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody/tr["+index+"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("Update")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            //driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
