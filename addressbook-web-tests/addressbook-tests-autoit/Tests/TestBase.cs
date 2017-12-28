﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        //[TestFixtureSetUp]

        public void InitApplication()
        {
            app = new ApplicationManager();
        }


        //[TestFixtureTearDown]

        public void stopApplication()
        {
            app.Stop();

        }
    }
}
