using Microsoft.VisualStudio.TestTools.UnitTesting;
using pqappdatastorage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectquailunittest
{
    [TestClass]
    public class PersistentGuidUnitTest
    {
        [TestMethod]
        public void PersistentGuid_BasicTest()
        {
            PersistentGuid pGuid = new PersistentGuid();
            Assert.IsTrue(pGuid.AppGuid != Guid.Empty);
        }
    }
}
