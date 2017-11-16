using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : TestBase
    {

        [Test]
        public void AddContactTest()
        {
            app.Navigator.ClickAddNew();
            ContactData group = new ContactData("Vera", "Long");
            group.Firstname = "Vera";
            group.Lastname = "Long";
            app.Contacts
                .FillNewContact(group)
                .SubmitNewContact();
            app.Auth.Logout();
        }
    }
}
