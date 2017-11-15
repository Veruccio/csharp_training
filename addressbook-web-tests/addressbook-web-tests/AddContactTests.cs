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
            OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            ClickAddNew();
            ContactData group = new ContactData("Vera", "Long");
            group.Firstname = "Vera";
            group.Lastname = "Long";
            FillNewContact(group);
            SubmitNewContact();
            Logout();
        }
    }
}
