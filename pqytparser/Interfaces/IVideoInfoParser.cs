using pqytparser.Models;
using pqytparser.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pqytparser.Interfaces
{
    public interface IVideoInfoParser
    {
        Task<VideoDownloadInfo> GetContentUriAsync(string contentId, string contentTitle, IList<MimeTypeEnum> mimeTypes, IList<FileTypeEnum> fileTypes);
    }
}
