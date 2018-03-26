using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.Storage;

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
        public async Task I18nRegionsJson_TestAsync()
        {
            string jsonContentPath = @"ms-appx:///pqlocalization/I18nRegions.json";
            Uri path = new Uri(jsonContentPath);

            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(path);
                // Convert.
                string content = await FileIO.ReadTextAsync(file);
                I18nRegionListReponse regions = JsonConvert.DeserializeObject<I18nRegionListReponse>(content);
                if ((regions?.Items?.Count ?? 0) < 1)
                    Assert.Fail("I18nRegions deserialization failed.");

                foreach (var region in regions.Items)
                    if (region.Snippet.Gl == "US")
                    {
                        Assert.IsTrue(region.Snippet.Name == "Worldwide (All)");
                        return;
                    }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.Fail("Region was not found.");
        }


        // Google.Apis.YouTube.v3.Data
        class I18nRegion : IDirectResponseScheme
        {
            public string ETag { get; set; }
            public string Id { get; set; }
            public string Kind { get; set; }
            public I18nRegionSnippet Snippet { get; set; }
        }

        // Google.Apis.YouTube.v3.Data
        class I18nRegionSnippet : IDirectResponseScheme
        {
            public string Gl { get; set; }
            public string Name { get; set; }
            public string ETag { get; set; }
        }

        // Google.Apis.YouTube.v3.Data
        class I18nRegionListReponse : IDirectResponseScheme
        {
            public string ETag { get; set; }
            public string EventId { get; set; }
            public IList<I18nRegion> Items { get; set; }
            public string Kind { get; set; }
            public string VisitorId { get; set; }
        }

        // Google.Apis.YouTube.v3.Data
        interface IDirectResponseScheme
        {
            string ETag { get; set; }
        }

    }
}
