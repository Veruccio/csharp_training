using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactCreated())
            {
                ContactData contact = new ContactData("Jacob", "Long");
                contact.Firstname = "Jacob";
                contact.Lastname = "Long";

                app.Contacts.CreateNewContact(contact);
            }
            app.Contacts.Remove(1);
        }
    }
}
