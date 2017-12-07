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
            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                if(contacts.Id == oldData.Id)
                {
                    Assert.AreEqual(newData, oldData);
                }
            }
        }
    }
}
