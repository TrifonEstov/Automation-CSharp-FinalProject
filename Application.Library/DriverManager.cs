using Application.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library
{
    public class DriverManager
    {
        private static IWebDriver _driver;

        public IWebDriver Driver => _driver;

        public void Start()
        {
            if (_driver == null)
            {
                LogContext.Logger.Info("Starting the browser");
                _driver = new ChromeDriver();
                LoadUrl();
                Driver.Manage().Window.Maximize();
            }
        }

        private void LoadUrl(string url = null)
        {
            if (url == null)
            {
                url = Configuration.Url;
            }
            LogContext.Logger.Info("Loading the URL" + url);
            Driver.Url = url;
        }

        public void Quit()
        {
            LogContext.Logger.Info("Closing the browser");
            Driver.Quit();
        }

        public void TakeScreenshot(string screenshotFileName)
        {
            var takeScreenshot = (ITakesScreenshot)Driver;
            var screenshot = takeScreenshot.GetScreenshot();
            string fileAbsolutePath = GetFilePath(Configuration.ScreenshotDirectoryName, screenshotFileName);
            screenshot.SaveAsFile(fileAbsolutePath);
        }

        private static string GetFilePath(string directoryName, string fileName)
        {
            string relativePath = $"\\{directoryName}";
            string baseDirPath = AppDomain.CurrentDomain.BaseDirectory;
            baseDirPath = baseDirPath.Replace("\\bin\\Debug\\net6.0\\", "");
            string directoryAbsolutePath = baseDirPath + relativePath + "\\";
            string fileFullName = fileName + ".png";
            string fileAbsolutePath = directoryAbsolutePath + fileFullName;
            return fileAbsolutePath;
        }
    }
}
