﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

        //ADDING CONTACT TO GROUP

        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public ContactHelper CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }
            
        public ContactHelper SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
            return this;
        }

        public ContactHelper ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            return this;
        }

        //REMOVING CONTACT FROM GROUP

        public ContactHelper RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectGroupFromFilter(group.Name);
            SelectContact(contact.Id);
            RemoveFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                 .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public ContactHelper RemoveFromGroup()
        {
            driver.FindElement(By.CssSelector("input[name=\"remove\"]")).Click();
            return this;
        }

        public ContactHelper SelectGroupFromFilter(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupName);
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

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            EditContact(contact.Id);
            FillNewContact(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            RemoveContact();
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
            contactCache = null;
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectContact(String contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper EditContact(String id)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'] and [href='edit.php?id={0})")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public void ShowContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
            .FindElements(By.TagName("td"))[6]
            .FindElement(By.TagName("a")).Click();
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

        private List<ContactData> contactCache = null;
        private string contactDetails;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = driver.FindElements(By.TagName("td"));
                    string Id = element.FindElement(By.Name("entry")).GetAttribute("value");
                    string lastName = cells[1].Text;
                    string firstName = cells[2].Text;

                    contactCache.Add(new ContactData(firstName, lastName)
                        {
                        Id = Id
                            });
                }
            }
            return new List<ContactData> (contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.TagName("td")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhome,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }


        public ContactData GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.OpenHomePage();
            ShowContactDetails(0);

            string сontactDetails = driver.FindElement(By.Id("content")).Text;

            return new ContactData(null, null)
            {
                ContactDetails = contactDetails
            };
        }
    }
}
