using pqytparser.Interfaces;
using pqytparser.Models;
using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqytparser.Parsers
{
    public class VideoInfoParser : IParser
    {
        public Task<VideoDownloadInfo> GetVideoDownloadInfoAsync(string contentId)
        {
            throw new NotImplementedException();
        }

        public void SetDesiredFileTypes(params FileTypeEnum[] fileTypes)
        {
            throw new NotImplementedException();
        }

        public void SetDesiredMimeTypes(params MimeTypeEnum[] mimeTypes)
        {
            throw new NotImplementedException();
        }
    }
}
