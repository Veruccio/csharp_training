using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupRemovalTests : GroupTestBase
    {

        [Test]

        public void GroupRemovalTest()
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
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}



    

