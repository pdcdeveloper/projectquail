using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqlib.AppStoreServices
{
    public interface IAppUpdater
    {
        Task<bool> DownloadAndInstallMostRecentVersionAsync();
    }
}
