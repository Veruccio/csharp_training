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

           if (!app.Groups.IsGroupCreated())
            {
                GroupData group = new GroupData("vera");
                group.Header = "my";
                group.Footer = "group";


                app.Groups.Create(group);

            }

            GroupData newData = new GroupData("leo");
            newData.Header = "new";
            newData.Footer = "long";

            app.Groups.Modify(1, newData);
        }
    }
}


    

        




