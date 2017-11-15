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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.ClickAddNew();
            ContactData group = new ContactData("Vera", "Long");
            group.Firstname = "Vera";
            group.Lastname = "Long";
            app.Contacts.FillNewContact(group);
            app.Contacts.SubmitNewContact();
            app.Auth.Logout();
        }
    }
}
