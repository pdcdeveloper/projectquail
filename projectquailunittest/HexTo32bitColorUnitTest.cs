using Microsoft.VisualStudio.TestTools.UnitTesting;
using pqhexhelper;
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

        [TestMethod]
        public void HasValidHexCharacters_Test()
        {
            int index = 0;

            string invalidLongLength = "fffffffff";
            string invalidShortLength = "ff";
            string invalidLengthWithHash = "#ff";
            string invalidCharacters = "#abcdefgh";

            string validCharacters = "fffffff1";
            string validHex = "FFFFFFFF";
            string validHexWithHash = "#FFFFFFFF";

            Assert.IsFalse(HexTo32bitColor.TryGetValidateStartingIndex(invalidLongLength, out index));
            Assert.IsTrue(index == -1);

            Assert.IsFalse(HexTo32bitColor.TryGetValidateStartingIndex(invalidShortLength, out index));
            Assert.IsTrue(index == -1);
            
            Assert.IsFalse(HexTo32bitColor.TryGetValidateStartingIndex(invalidLengthWithHash, out index));
            Assert.IsTrue(index == -1);

            Assert.IsFalse(HexTo32bitColor.TryGetValidateStartingIndex(invalidCharacters, out index));
            Assert.IsTrue(index == -1);

            Assert.IsTrue(HexTo32bitColor.TryGetValidateStartingIndex(validCharacters, out index));
            Assert.IsTrue(index == 0);

            Assert.IsTrue(HexTo32bitColor.TryGetValidateStartingIndex(validHex, out index));
            Assert.IsTrue(index == 0);

            Assert.IsTrue(HexTo32bitColor.TryGetValidateStartingIndex(validHexWithHash, out index));
            Assert.IsTrue(index == 1);
        }

    }
}
