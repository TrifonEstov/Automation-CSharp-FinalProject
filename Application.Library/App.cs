using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library
{
    public class App
    {
        private IWebDriver Driver { get; init; }

        public App (IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
