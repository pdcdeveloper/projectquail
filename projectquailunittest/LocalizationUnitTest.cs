using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;

namespace projectquailunittest
{
    // NOTES:
    //              Assertion will fail if 'ResourceContext.QualiferValues["language"]' value is changed and not reset.  This is true for both cached
    //          and locally instantiated 'ResourceLoader'.  An exception to this would be if 'ResourceContext.QualifierValues["language"]' value is changed
    //          to the system's default language, such as "en-US".
    //          
    [TestClass]
    public class LocalizationUnitTest
    {
        // 'GetForViewIndependentUse()' is required because CoreWindow does not exist in this thread.
        ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse("pqlocalization");
        ResourceContext _resourceContext = ResourceContext.GetForViewIndependentUse();

        [TestMethod]
        public void ResourcesEnglish_Test()
        {
            string greeting = _resourceLoader.GetString("Resources/Greeting");
            Assert.IsTrue(_resourceContext.QualifierValues["language"] == "en-US", "Language qualifier value is: " + _resourceContext.QualifierValues["language"]);
            Assert.IsTrue(!string.IsNullOrEmpty(greeting), "Greeting value is null or empty.");
            Assert.IsTrue(greeting == "Hello, World!", "Greeting value is: " + greeting);
        }
        
        [TestMethod]
        public void ResourcesLatin_Test()
        {
            _resourceContext.QualifierValues["language"] = "la-US";
            string greeting = _resourceLoader.GetString("Resources/Greeting");
            Assert.IsTrue(!string.IsNullOrEmpty(greeting), "Greeting value is null or empty.");
            Assert.IsTrue(greeting == "Salve, Orbis Terrarum!", "Greeting value is: " + greeting);
            _resourceContext.Reset();   // Qualifier values are global and will affect all calls to 'ResourceLoader.GetString()'.
        }

        [TestMethod]
        public void Resources_ResourceContextDefaultLanguageTest()
        {
            // Cache the default language.
            _resourceContext.Reset();
            string defaultLanguage = _resourceContext.QualifierValues["language"];
            Assert.IsTrue(!string.IsNullOrEmpty(defaultLanguage), "Default language value is null or empty.");

            // Change the language qualifier.
            _resourceContext.QualifierValues["language"] = "la-US";
            if (defaultLanguage == _resourceContext.QualifierValues["language"])
            {
                Assert.IsTrue(defaultLanguage == _resourceContext.QualifierValues["language"]);
                _resourceContext.Reset();
                return;
            }
            Assert.IsTrue(defaultLanguage != _resourceContext.QualifierValues["language"], "Language is: " + _resourceContext.QualifierValues["language"]);
            _resourceContext.Reset();
        }
    }
}
