using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace projectquailunittest
{
    [TestClass]
    public class SolidColorBrushUnitTest
    {
        [TestMethod]
        public void SolidColorBrush_FromStringTest()
        {
            var color = "PeachPuff".ToColor();
            Assert.IsTrue(color == Colors.PeachPuff);

            var hexColor = "#FF171717";
            color = "#FF171717".ToColor();
            Assert.IsTrue(color == Color.FromArgb(
                byte.Parse(hexColor.Substring(1, 2), NumberStyles.HexNumber),
                byte.Parse(hexColor.Substring(3, 2), NumberStyles.HexNumber),
                byte.Parse(hexColor.Substring(5, 2), NumberStyles.HexNumber),
                byte.Parse(hexColor.Substring(7, 2), NumberStyles.HexNumber)));
        }
    }
}
