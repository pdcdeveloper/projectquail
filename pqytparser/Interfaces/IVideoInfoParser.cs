using pqytparser.Models;
using pqytparser.Resources;
using System.Threading.Tasks;

namespace pqytparser.Interfaces
{
    public interface IVideoInfoParser
    {
        void SuggestFileTypes(params FileTypeEnum[] suggestions);
        void SuggestMimeTypes(params MimeTypeEnum[] suggestions);
        Task<VideoDownloadInfo> GetContentUriAsync(string contentId);
    }
}
