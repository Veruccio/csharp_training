using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



namespace WebAddressbookTests
{
    [TestFixture]

    public class  GroupRemovalTests: AuthTestBase
    {
       
        [Test]

        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}

    

