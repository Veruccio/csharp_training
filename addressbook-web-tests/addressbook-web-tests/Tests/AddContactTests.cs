using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Contacts.CreateNewContact(contact);
        }

        [Test]
        public void AddEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Firstname = "";
            contact.Lastname = "";

            app.Contacts.CreateNewContact(contact);
        }
    }
}
