using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class  GroupRemovalTests: TestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
    }
}
    

