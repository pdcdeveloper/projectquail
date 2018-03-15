using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectquailunittest
{
    [TestClass]
    public class HexTo32bitColorUnitTest
    {
        [TestMethod]
        public void Byte_TryParseTest()
        {
            if (!Byte.TryParse("FF", NumberStyles.HexNumber, null, out byte result))
                Assert.Fail("Byte.TryParse() has failed while parsing the value:  FF");
            Assert.IsTrue(result == 0xFF);

            if (!Byte.TryParse("#FF", NumberStyles.HexNumber, null, out result))
                Assert.IsTrue(result == Byte.MinValue);

            if (!Byte.TryParse("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber, null, out result))
                Assert.IsTrue(result == Byte.MinValue);

            if (!Byte.TryParse("", NumberStyles.HexNumber, null, out result))
                Assert.IsTrue(result == Byte.MinValue);

            if (!Byte.TryParse("fffzffff", NumberStyles.HexNumber, null, out result))
                Assert.IsTrue(result == Byte.MinValue);
        }
    }
}
