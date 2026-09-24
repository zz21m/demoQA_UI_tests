using Framework.Drivers;
using Framework.Managers;
using Framework.Utilities;
using Framework.Browser;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Logger.Info($"Test started: {TestContext.CurrentContext.Test.Name}");
            DriverManager.Driver.Navigate().GoToUrl(ConfigManager.Config.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Logger.Info($"Test finished: {TestContext.CurrentContext.Test.Name}");
            DriverManager.QuitDriver();   
        }
    }
}
