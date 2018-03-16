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
        const string _invalidSignAtBeginning = "-aBbCcDd";
        const string _invalidSignAtBeginningWithHash = "#-aBbCcDd";
        const string _invalidCharacterAtEnd = "AaBbCcD_";
        const string _invalidCharacterAtEndWithHash = "#AaBbCcD-";
        const string _invalidLengthShort = "a";
        const string _invalidLengthLong = "AAAAAAAAAAAAAA";
        const string _invalidAlphaWithHash = "#zaBbCcDd";
        const string _validColorWithHash = "#AaBbCcDd";
        const string _validColor = "AaBbCcDd";

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

        [TestMethod]
        public void TryGetArgb_Test()
        {
            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidSignAtBeginning, out var argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidSignAtBeginningWithHash, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidCharacterAtEnd, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidCharacterAtEndWithHash, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidLengthShort, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidLengthLong, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsFalse(HexTo32bitColor.TryGetArgb(_invalidAlphaWithHash, out argb));
            Assert.IsTrue(argb.alpha == Byte.MinValue);
            Assert.IsTrue(argb.red == Byte.MinValue);
            Assert.IsTrue(argb.green == Byte.MinValue);
            Assert.IsTrue(argb.blue == Byte.MinValue);

            Assert.IsTrue(HexTo32bitColor.TryGetArgb(_validColorWithHash, out argb));
            Assert.IsFalse(argb.alpha == Byte.MinValue);
            Assert.IsFalse(argb.red == Byte.MinValue);
            Assert.IsFalse(argb.green == Byte.MinValue);
            Assert.IsFalse(argb.blue == Byte.MinValue);

            Assert.IsTrue(HexTo32bitColor.TryGetArgb(_validColor, out argb));
            Assert.IsFalse(argb.alpha == Byte.MinValue);
            Assert.IsFalse(argb.red == Byte.MinValue);
            Assert.IsFalse(argb.green == Byte.MinValue);
            Assert.IsFalse(argb.blue == Byte.MinValue);
        }

        [TestMethod]
        public void TryGetAlpha_Test()
        {

        }

        [TestMethod]
        public void TryGetRed_Test()
        {

        }

        [TestMethod]
        public void TryGetGreen_Test()
        {

        }

        [TestMethod]
        public void TryGetBlue_Test()
        {

        }

    }
}
