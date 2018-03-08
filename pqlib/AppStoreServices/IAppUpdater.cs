﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;

namespace pqlib.AppStoreServices
{
    public interface IAppUpdater
    {
        Task<StorePackageUpdateState> DownloadAndInstallMostRecentVersionAsync();
    }
}