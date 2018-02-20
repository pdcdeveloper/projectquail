using pqytparser.Models;
using System.Threading.Tasks;

namespace pqytparser.Interfaces
{
    public interface IVideoInfoService
    {
        Task<VideoDownloadInfo> GetContentUriAsync(string contentId);
    }
}
