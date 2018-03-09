using System;
using Windows.Storage;

namespace pqappdatastorage.Models
{
    // Assigns to your application a unique guid that persist in storage (local settings container.)
    // A unique guid is generated when your application first runs on the user's system after it is installed.  Generally,
    // the only way to change this guid is to uninstall, then reinstall the app.
    // 
    // <see cref="https://stackoverflow.com/questions/2344098/c-sharp-how-to-create-a-guid-value"/>
    // <see cref="https://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.backgroundtransfer.backgrounddownloader.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1"/>
    // A unique guid for your app is required to retrieve your app's background download operations.
    // Without a unique guid (per app), other installed applications may also retrieve any other application's background download operations.
    // Always associate a background task with your app's unique guid and use the same guid throught the application lifetime (from installation to uninstallation.)
    public struct PersistentGuid
    {
        Guid _appGuid;
        public Guid AppGuid { get => _appGuid == Guid.Empty ? _appGuid = GetGuid() : _appGuid; }

        // Deserializes the existing guid value from the local settings container
        // or creates a new guid if one does not exist.
        Guid GetGuid()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(nameof(AppGuid)))
                return (Guid)localSettings.Values[nameof(AppGuid)];
            else
                return (Guid)(localSettings.Values[nameof(AppGuid)] = Guid.NewGuid());
        }
    }
}
