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
    public sealed class PersistentGuid
    {
        Guid _appGuid;
        public Guid AppGuid { get => _appGuid == Guid.Empty ? _appGuid = GetGuid() : _appGuid; }

        public PersistentGuid()
        {
            // If the guid currently does not exist within the container, then generate a new guid for the application.
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(nameof(AppGuid)))
                ApplicationData.Current.LocalSettings.Values[nameof(AppGuid)] = Guid.NewGuid();

            // Deserialize the guid value from the container.
            _appGuid = GetGuid();
        }

        Guid GetGuid()
        {
            return (Guid)ApplicationData.Current.LocalSettings.Values[nameof(AppGuid)];
        }
    }
}
