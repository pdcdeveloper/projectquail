using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;

namespace projectquailunittest
{
    [TestClass]
    public class I18nRegionsUnitTest
    {
        // https://stackoverflow.com/questions/28505933/using-resourceloader-getstring-method-to-retrieve-resources-with-dots-in-the-key
        [TestMethod]
        public void I18nRegionsResw_Test()
        {
            var resourceLoader = ResourceLoader.GetForViewIndependentUse("pqlocalization/I18nRegions");
            string resource = resourceLoader.GetString("Worldwide/Gl");
            Assert.IsTrue(resource == "US");
            resource = resourceLoader.GetString("Worldwide/Name");
            Assert.IsTrue(resource == "Worldwide (All)");
        }

        [TestMethod]
        public void I18nRegionsJson_Test()
        {

        }
    }
}
