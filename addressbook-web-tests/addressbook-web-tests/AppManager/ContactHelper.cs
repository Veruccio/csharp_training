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
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            //SelectContact(v);
            EditContact(v);
            FillNewContact(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            //EditContact(v);
            RemoveContact();
            ReturnToContactsPage();
            return this;
        }


        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillNewContact(ContactData account)
        {

            Type(By.Name("firstname"), account.Firstname);
            Type(By.Name("lastname"), account.Lastname);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public void ContactCreated()
        {
            if (IsContactCreated())
            {
                return;
            }

            ContactData contact = new ContactData("Vera", "Long");
            contact.Firstname = "Vera";
            contact.Lastname = "Long";

            CreateNewContact(contact);
        }

        public bool IsContactCreated()
        {
            return IsElementPresent(By.CssSelector("td.center"));
        }


        public List<ContactData> GetContactsList()
        {
            string[] ContactDetails = new string[] { "firstname", "lastname" };

            List<ContactData> contact = new List<ContactData>();

            manager.Navigator.OpenHomePage();

            ICollection <IWebElement> elements  = driver.FindElements(By.TagName("tr"));

            foreach (IWebElement element in elements)
            {
                contact.Add(new ContactData(element.Text));
            }
           return contact;
        }
    }
}
