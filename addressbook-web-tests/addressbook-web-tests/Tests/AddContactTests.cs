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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(80),
                    Lastname = GenerateRandomString(80)
                });
            }
                return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]

        public void AddContactTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateNewContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
