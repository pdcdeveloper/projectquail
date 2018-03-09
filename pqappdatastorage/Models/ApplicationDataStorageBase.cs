using Windows.Storage;

namespace pqappdatastorage.Models
{
    // Provides a single method to write a key-value pair to an 'Windows.Storage.ApplicationDataContainer'.
    public abstract class ApplicationDataStorageBase
    {
        public virtual void WriteToContainer(ApplicationDataContainer container, string key, object value)
        {
            if (container != null && !string.IsNullOrEmpty(key))
                container.Values[key] = value;
        }
    }
}
