using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using pqlocalization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace projectquailunittest
{
    [TestClass]
    public class AppVersionInfoUnitTest
    {
        [TestMethod]
        public async Task VersionInfo_DeserializeTestAsync()
        {
            string jsonContentPath = @"ms-appx:///TestAppVersionInfo.json";
            Uri path = new Uri(jsonContentPath);

            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(path);
                // Convert.
                string content = await FileIO.ReadTextAsync(file);
                var versionInfo = JsonConvert.DeserializeObject<AppVersionInfo>(content);

                Assert.IsTrue(!string.IsNullOrEmpty(versionInfo.AppName));
                Assert.IsTrue(versionInfo.AppName == "QuailTube");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
