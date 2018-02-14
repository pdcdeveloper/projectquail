namespace pqytparser.Resources
{
    /// <summary>
    /// This enumeration is based on YouTube's itag parameter.  The integral value of each enum mber is its corresponding itag.
    /// </summary>
    public enum MediaQualityEnum
    {
        // Default value to avoid using nullable
        Unknown = 0,

        Flv_240p = 5,


        Gggp_144p = 17,
        Mp4_360p = 18,
        Mp4_720p = 22,
        Flv_360p = 34,
        Flv_480p = 35,
        Gggp_240p = 36,
        Mp4_3072p = 38,
        Webm_360p = 43,
        Webm_480p = 44,
        Webm_720p = 45,
        Webm_1080p = 46,


        Mp4_360p_3d = 82,
        Mp4_480p_3d = 83,
        Mp4_720p_3d = 84,
        Mp4_1080p_3d = 85,
        Webm_360p_3d = 100,
        Webm_480p_3d = 101,
        Webm_1080p_3d = 102,


        Mp4_240p_Avc = 133,
        Mp4_360p_Avc = 134,
        Mp4_480p_Avc = 135,
        Mp4_720p_Avc = 136,
        Mp4_1080p_Avc = 137,

        M4a_Low_Aac = 139,
        M4a_Mid_Aac = 140,
        M4a_High_Aac = 141,


        Mp4_144p_Avc = 160,


        Webm_Mid_Vorbis = 171,


        Webm_240p_Vp9 = 242,
        Webm_360p_Vp9 = 243,
        Webm_480p_Vp9 = 244,


        Webm_720p_Vp9 = 247,
        Webm_1080p_Vp9 = 248,


        Webm_Low_Opus = 249,
        Webm_Mid_Opus = 250,
        Webm_High_Opus = 251,


        Mp4_1440p_Avc = 264,
        Mp4_2160p_Avc = 266,


        Webm_1440p_Vp9 = 271,
        Webm_2160p_Vp9 = 272,


        Webm_144p_Vp9 = 278,


        Mp4_720p60fps_Avc = 298,
        Mp4_1080p60fps_Avc = 299,


        Webm_720p60fps_Vp9 = 302,
        Webm_1080p60fps_Vp9 = 303,
        Webm_1440p60fps_Vp9 = 308,
        Webm_2160p60fps_Vp9 = 315
    }
}
