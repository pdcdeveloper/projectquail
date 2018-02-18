﻿using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    /// <summary>
    /// This enumeration is based on YouTube's itag parameter.  The integral value of each enum member is its corresponding itag.
    /// </summary>
    /// <remarks>
    /// DisplayAttribute holds key metadata for each member:
    ///     Name        = quality (append this to file name before the file extension)
    ///     ShortName   = file type (file extension)
    ///     Description = mime type
    /// </remarks>
    public enum MediaQualityEnum
    {
        // Default value to avoid using nullable
        [Display(Name = "0", ShortName = "0", Description = "0")]
        Unknown = 0,


        [Display(Name = "240p", ShortName = FileExtensions.Flv, Description = MimeTypes.MuxedAudioVideo)]
        Flv_240p = 5,


        [Display(Name = "144p", ShortName = FileExtensions.Gggp, Description = MimeTypes.MuxedAudioVideo)]
        Gggp_144p = 17,
        [Display(Name = "360p", ShortName = FileExtensions.Mp4, Description = MimeTypes.MuxedAudioVideo)]
        Mp4_360p = 18,
        [Display(Name = "720p", ShortName = FileExtensions.Mp4, Description = MimeTypes.MuxedAudioVideo)]
        Mp4_720p = 22,
        [Display(Name = "360p", ShortName = FileExtensions.Flv, Description = MimeTypes.MuxedAudioVideo)]
        Flv_360p = 34,
        [Display(Name = "480p", ShortName = FileExtensions.Flv, Description = MimeTypes.MuxedAudioVideo)]
        Flv_480p = 35,
        [Display(Name = "240p", ShortName = FileExtensions.Gggp, Description = MimeTypes.MuxedAudioVideo)]
        Gggp_240p = 36,
        [Display(Name = "3072p", ShortName = FileExtensions.Mp4, Description = MimeTypes.MuxedAudioVideo)]
        Mp4_3072p = 38,
        [Display(Name = "360p", ShortName = FileExtensions.Webm, Description = MimeTypes.MuxedAudioVideo)]
        Webm_360p = 43,
        [Display(Name = "480p", ShortName = FileExtensions.Webm, Description = MimeTypes.MuxedAudioVideo)]
        Webm_480p = 44,
        [Display(Name = "720p", ShortName = FileExtensions.Webm, Description = MimeTypes.MuxedAudioVideo)]
        Webm_720p = 45,
        [Display(Name = "1080p", ShortName = FileExtensions.Webm, Description = MimeTypes.MuxedAudioVideo)]
        Webm_1080p = 46,


        [Display(Name = "360p 3d", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video3d)]
        Mp4_360p_3d = 82,
        [Display(Name = "480p 3d", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video3d)]
        Mp4_480p_3d = 83,
        [Display(Name = "720p 3d", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video3d)]
        Mp4_720p_3d = 84,
        [Display(Name = "1080p 3d", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video3d)]
        Mp4_1080p_3d = 85,
        [Display(Name = "360p 3d", ShortName = FileExtensions.Webm, Description = MimeTypes.Video3d)]
        Webm_360p_3d = 100,
        [Display(Name = "480p 3d", ShortName = FileExtensions.Webm, Description = MimeTypes.Video3d)]
        Webm_480p_3d = 101,
        [Display(Name = "1080p 3d", ShortName = FileExtensions.Webm, Description = MimeTypes.Video3d)]
        Webm_1080p_3d = 102,


        [Display(Name = "240p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_240p_Avc = 133,
        [Display(Name = "360p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_360p_Avc = 134,
        [Display(Name = "480p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_480p_Avc = 135,
        [Display(Name = "720p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_720p_Avc = 136,
        [Display(Name = "1080p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_1080p_Avc = 137,

        [Display(Name = "low aac", ShortName = FileExtensions.M4a, Description = MimeTypes.Audio)]
        M4a_Low_Aac = 139,
        [Display(Name = "mid aac", ShortName = FileExtensions.M4a, Description = MimeTypes.Audio)]
        M4a_Mid_Aac = 140,
        [Display(Name = "high aac", ShortName = FileExtensions.M4a, Description = MimeTypes.Audio)]
        M4a_High_Aac = 141,


        [Display(Name = "144p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_144p_Avc = 160,


        [Display(Name = "mid vorbis", ShortName = FileExtensions.Webm, Description = MimeTypes.Audio)]
        Webm_Mid_Vorbis = 171,


        [Display(Name = "240p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_240p_Vp9 = 242,
        [Display(Name = "360p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_360p_Vp9 = 243,
        [Display(Name = "480p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_480p_Vp9 = 244,


        [Display(Name = "720p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_720p_Vp9 = 247,
        [Display(Name = "1080p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_1080p_Vp9 = 248,


        [Display(Name = "low opus", ShortName = FileExtensions.Webm, Description = MimeTypes.Audio)]
        Webm_Low_Opus = 249,
        [Display(Name = "mid opus", ShortName = FileExtensions.Webm, Description = MimeTypes.Audio)]
        Webm_Mid_Opus = 250,
        [Display(Name = "high opus", ShortName = FileExtensions.Webm, Description = MimeTypes.Audio)]
        Webm_High_Opus = 251,


        [Display(Name = "1440p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_1440p_Avc = 264,
        [Display(Name = "2160p avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_2160p_Avc = 266,


        [Display(Name = "1440p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_1440p_Vp9 = 271,
        [Display(Name = "2160p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_2160p_Vp9 = 272,


        [Display(Name = "144p vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_144p_Vp9 = 278,


        [Display(Name = "720p60fps avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_720p60fps_Avc = 298,
        [Display(Name = "1080p60fps avc", ShortName = FileExtensions.Mp4, Description = MimeTypes.Video)]
        Mp4_1080p60fps_Avc = 299,


        [Display(Name = "720p60fps vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_720p60fps_Vp9 = 302,
        [Display(Name = "1080p60fps vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_1080p60fps_Vp9 = 303,
        [Display(Name = "1440p60fps vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_1440p60fps_Vp9 = 308,
        [Display(Name = "2160p60fps vp9", ShortName = FileExtensions.Webm, Description = MimeTypes.Video)]
        Webm_2160p60fps_Vp9 = 315
    }
}
