using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;

namespace pqlib.AppStoreServices
{
    // Provides methods to automatically check for and install updates when you upload new packages to your app submission.
    // This implementation currently has no license checking.
    // <see cref="https://docs.microsoft.com/en-us/windows/uwp/packaging/self-install-package-updates"/>
    public class AppUpdater : IAppUpdater
    {
        StoreContext _storeContext;

        public AppUpdater(StoreContext storeContext = null)
        {
            _storeContext = storeContext ?? StoreContext.GetDefault();
        }

        public Task<bool> DownloadAndInstallMostRecentVersionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
