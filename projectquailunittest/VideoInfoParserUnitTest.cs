using Microsoft.VisualStudio.TestTools.UnitTesting;
using pqytparser.Interfaces;
using pqytparser.Resources;
using pqytparser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectquailunittest
{
    [TestClass]
    public class VideoInfoParserUnitTest
    {
        IVideoInfoParser _videoInfoParser = new VideoInfoParser();


        [TestMethod]
        public async Task GetContentUriAsync_DynamicTest()
        {
            // "Monster Hunter World" by videogamedunkey.
            IList<MimeTypeEnum> mimeTypes = new List<MimeTypeEnum>() { MimeTypeEnum.Audio, MimeTypeEnum.Video, MimeTypeEnum.MuxedAudioVideo };
            IList<FileTypeEnum> fileTypes = new List<FileTypeEnum>() { FileTypeEnum.M4a, FileTypeEnum.Mp4, FileTypeEnum.Webm };

            var info = await _videoInfoParser.GetContentUriAsync("Mxv9AM397Y8", "Monster Hunter World", mimeTypes, fileTypes);

            if (info.Availability == VideoAvailabilityEnum.NotAvailable)
                Assert.IsTrue(info.ErrorMessage.ToLower().Contains("not found"));
            else
                Assert.IsTrue(info.Availability == VideoAvailabilityEnum.Available);
        }
    }
}
