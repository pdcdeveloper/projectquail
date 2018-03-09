using System.Threading.Tasks;
using Windows.Services.Store;

namespace pqappstoreservices.Interfaces
{
    public interface IAppUpdater
    {
        Task<StorePackageUpdateState> DownloadAndInstallMostRecentVersionAsync();
    }
}
