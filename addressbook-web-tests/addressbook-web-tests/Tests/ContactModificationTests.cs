using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactCreated())
            {
                ContactData contact = new ContactData("Jacob", "Long");
                contact.Firstname = "Jacob";
                contact.Lastname = "Long";

                app.Contacts.CreateNewContact(contact);
            }

            ContactData newData = new ContactData("Leo", "Shev");
            newData.Firstname = "Leo";
            newData.Lastname = "Shev";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
