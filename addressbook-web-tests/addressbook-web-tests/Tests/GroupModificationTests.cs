using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();

            Assert.IsTrue(app.Groups.IsGroupCreated());

            GroupData newData = new GroupData("zzz");
            newData.Header = "www";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }
    }
}


    

        




