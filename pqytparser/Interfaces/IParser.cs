﻿using pqytparser.Models;
using pqytparser.Resources;
using System.Threading.Tasks;

namespace pqytparser.Interfaces
{
    public interface IParser
    {
        void SetDesiredMimeTypes(params MimeTypeEnum[] mimeTypes);
        void SetDesiredFileTypes(params FileTypeEnum[] fileTypes);
        Task<VideoDownloadInfo> GetVideoDownloadInfoAsync(string contentId);
    }
}