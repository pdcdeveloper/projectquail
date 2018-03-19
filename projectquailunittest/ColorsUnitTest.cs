using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI;
using System.Reflection;
using System.Diagnostics;

namespace projectquailunittest
{
    [TestClass]
    public class ColorsUnitTest
    {
        [TestMethod]
        public void ColorsToHex_Test()
        {
            MemberInfo[] members = typeof(Colors).GetMembers();
            foreach (var member in members)
                if (member.DeclaringType == typeof(Colors) && member.MemberType == MemberTypes.Property)
                    Debug.WriteLine(member.Name + " == " + member.Name.ToColor().ToHex());
        }
    }
}
