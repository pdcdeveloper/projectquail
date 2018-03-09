using Windows.Storage;

namespace pqappdatastorage.Models
{
    // Uses the application's local settings container to store key-value pairs.
    public abstract class LocalSettingsStorageBase
    {
        const string _containerName = "applocalsettings";
        public ApplicationDataContainer LocalSettings { get; private set; }

        public LocalSettingsStorageBase()
        {
            LocalSettings = ApplicationData.Current.LocalSettings.CreateContainer(_containerName, ApplicationDataCreateDisposition.Always);
        }

        public virtual void WriteToContainer(ApplicationDataContainer container, string key, object value)
        {
            if (container != null && !string.IsNullOrEmpty(key))
                container.Values[key] = value;
        }
    }
}
