using Application.Library;
using Application.Testing.Logging;
using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Application.Testing.Hooks
{
    public class MainHooks
    {
        private IObjectContainer ObjectContainer { get; set; }

        private DriverManager DriverManager { get; set; }

        public MainHooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [Before(Order =1)]
        public void InitialiseProperties()
        {
            Logger = new TestLogger();
            App app = new App(DriverManager.Driver);
            ObjectContainer.RegisterInstanceAs(app);

            Dictionary<string, dynamic> testData = new Dictionary<string, dynamic>();
            ObjectContainer.RegisterInstanceAs(testData);
        }

        [AfterScenario(Order =1)]
        public void Report()
        {
            try
            {
                string testName = TestContext.CurrentContext.Test.Name;
                if (TestContext.CurrentContext.Result.FailCount > 0)
                {
                    Logger.Error("Test " + testName + " failed!");
                    DriverManager.TakeScreenshot(testName);
                }
                else
                {
                    Logger.Info("Test " + testName + " passed!");
                }
            }
            catch
            {
                Logger.Warning("Something went wrong with the Report hook.");
            }
        }

        [After(Order =2)]
        public void StopBrowser()
        {
            DriverManager.Quit();
        }
    }
}
