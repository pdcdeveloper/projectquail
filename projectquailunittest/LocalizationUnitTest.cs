using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace projectquailunittest
{
    [TestClass]
    public class LocalizationUnitTest
    {
        ResourceLoader _resourceLoader = ResourceLoader.GetForCurrentView();

        [TestMethod]
        public void ResourcesEnglish_Test()
        {
            string greeting = _resourceLoader.GetString("Greeting");
            Assert.IsTrue(!string.IsNullOrEmpty(greeting));
            Assert.IsTrue(greeting == "Hello, World!");
        }

        [TestMethod]
        public void ResourcesLatin_Test()
        {

        }
    }
}
