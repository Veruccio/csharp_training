using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit.Tests
{
    [TestFixture]

    class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTestAutoIt()
        {

            if (!app.Groups.IsGroupCreated())
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "vera"
                };
                app.Groups.Add(newGroup);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
