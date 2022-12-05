using Application.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Testing.StepDefinitions
{
    public abstract class BaseStepDefinitions
    {
        protected App App { get; private set; }

        protected Dictionary<string, dynamic> TestData { get; private set; }
        
        public BaseStepDefinitions(App app, Dictionary<string, dynamic> testData)
        {
            App = app;
            TestData = testData;
        }
    }
}
