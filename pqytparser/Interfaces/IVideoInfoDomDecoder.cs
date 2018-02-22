using pqytparser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqytparser.Interfaces
{
    public interface IVideoInfoDomDecoder
    {
        VideoDownloadInfo GetVideoDownloadInfo(string contentId);
    }
}
