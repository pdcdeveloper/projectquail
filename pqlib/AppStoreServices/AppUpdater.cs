using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;
using Windows.UI.Popups;

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

        public async Task<StorePackageUpdateState> DownloadAndInstallMostRecentVersionAsync()
        {
            if (_storeContext == null)
            {
                return StorePackageUpdateState.OtherError;
            }

            // Get available updates.
            var updates = await _storeContext.GetAppAndOptionalStorePackageUpdatesAsync();
            if ((updates?.Count ?? 0) < 1)
            {
                return StorePackageUpdateState.OtherError;  // No updates were found
            }

            // Content verification.
            foreach (var update in updates)
                if (!await update.Package.VerifyContentIntegrityAsync())
                    return StorePackageUpdateState.OtherError;

            // Download and install.
            // This method will automatically show a consent dialog.
            var downloadOperation = _storeContext.RequestDownloadAndInstallStorePackageUpdatesAsync(updates);

            // Show the message dialog.
            var result = await downloadOperation.AsTask();
            switch (result.OverallState)
            {
                case StorePackageUpdateState.OtherError:
                    MessageDialog mdialog = new MessageDialog("An app update was detected, but may still be unavailable to download.  Please try updating again at a later time.");
                    mdialog.Commands.Add(new UICommand("Close this dialog"));
                    IUICommand command = await mdialog.ShowAsync();
                    break;
            }

            return result.OverallState;
        }
    }
}
