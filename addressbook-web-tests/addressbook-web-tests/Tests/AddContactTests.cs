using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : AuthTestBase
    {

        [Test]
        public void AddContactTest()
        {
            ContactData contact = new ContactData("Vera", "Long");
            contact.Firstname = "Vera";
            contact.Lastname = "Long";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateNewContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

        }

        [Test]
        public void AddEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Firstname = "";
            contact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateNewContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

        }
    }
}
