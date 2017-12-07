using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }


        [Test]

        public void TestDetailsContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetailsForm(0);

            Assert.AreEqual(fromTable, fromDetails);
            Assert.AreEqual(fromTable.Address, fromDetails.Address);
            Assert.AreEqual(fromTable.AllPhones, fromDetails.AllPhones);
        }
    }
}
