using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            GroupData toBeModified = oldGroups[0];

            GroupData newData = new GroupData("leo");
            newData.Header = "new";
            newData.Footer = "long";

            app.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(toBeModified.Id, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}


    

        




