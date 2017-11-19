﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
        }
    }
}