using Microsoft.VisualStudio.TestTools.UnitTesting;
using pqcommonui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectquailunittest
{
    [TestClass]
    public class PrettyPrintExtensionUnitTest
    {
        const string EmDash = "\x2014";
        const string NonBreakingSpace = "\xA0";

        [TestMethod]
        public void ColonDelineatedTimeFormat_Test()
        {
            string test1 = TimeSpan.FromSeconds(121).ColonDelineatedTimeFormat();
            Assert.IsTrue(test1 == "02:01");

            string test2 = TimeSpan.FromSeconds(3601).ColonDelineatedTimeFormat();
            Assert.IsTrue(test2 == "01:00:01");

            string test3 = TimeSpan.FromSeconds(0).ColonDelineatedTimeFormat();
            Assert.IsTrue(test3 == "00:00");
        }

        [TestMethod]
        public void DelineateNumber_Test()
        {
            string test1 = PrettyPrintExtension.DelineatePositiveNumber(0);
            Assert.IsTrue(test1 == EmDash + NonBreakingSpace + EmDash);

            string test2 = PrettyPrintExtension.DelineatePositiveNumber(-1);
            Assert.IsTrue(test2 == EmDash + NonBreakingSpace + EmDash);
        }

        [TestMethod]
        public void DecodeISO8601Duration_Test()
        {
            string test1 = "".DecodeISO8601Duration();
            Assert.IsTrue(test1 == EmDash + ":" + EmDash);

            string test2 = "pz15".DecodeISO8601Duration();
            Assert.IsTrue(test2 == EmDash + ":" + EmDash);

            string test3 = "ptz15".DecodeISO8601Duration();
            Assert.IsTrue(test3 == EmDash + ":" + EmDash);

            string test4 = "pt15mm".DecodeISO8601Duration();
            Assert.IsTrue(test4 == EmDash + ":" + EmDash);

            string test5 = "pt15m111".DecodeISO8601Duration();
            Assert.IsTrue(test5 == EmDash + ":" + EmDash);

            string test6 = "pt00m00s00".DecodeISO8601Duration();
            Assert.IsTrue(test6 == EmDash + ":" + EmDash);

            string test7 = "pt100m11".DecodeISO8601Duration();
            Assert.IsTrue(test7 == EmDash + ":" + EmDash);

            string test8 = "pt100m1s2".DecodeISO8601Duration();
            Assert.IsTrue(test8 == EmDash + ":" + EmDash);

            string test9 = "PT23H".DecodeISO8601Duration();
            Assert.IsTrue(test9 == "23:00:00");

            string test10 = "pth".DecodeISO8601Duration();
            Assert.IsTrue(test10 == EmDash + ":" + EmDash);

            string test11 = "pt25h61m71s".DecodeISO8601Duration();  // test11 == "02:02:11"
            Assert.IsTrue(test11 != EmDash + ":" + EmDash);         // time values were wrapped instead of carried

            string test12 = "pt1h02m3s".DecodeISO8601Duration();
            Assert.IsTrue(test12 == "01:02:03");
        }
    }
}
