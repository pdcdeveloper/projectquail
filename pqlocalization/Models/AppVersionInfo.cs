using Newtonsoft.Json;

namespace pqlocalization.Models
{
    public struct AppVersionInfo
    {
        [JsonProperty(nameof(AppName))]
        public string AppName { get; set; }

        [JsonProperty(nameof(DevelopmentTeam))]
        public string DevelopmentTeam { get; set; }

        [JsonProperty(nameof(CurrentVersion))]
        public PatchInfo CurrentVersion { get; set; }

        [JsonProperty(nameof(PreviousVersions))]
        public PatchInfo[] PreviousVersions { get; set; }
    }

    public struct PatchInfo
    {
        // "Major.Minor.Build.Revision" or "Major.Minor.MajorPatch.MinorPatch".
        [JsonProperty(nameof(Version))]
        public string Version { get; set; }

        // "MMMM d, yyyy"
        [JsonProperty(nameof(PublishedAt))]
        public string PublishedAt { get; set; }

        [JsonProperty(nameof(Changes))]
        public PatchNote[] Changes { get; set; }
    }

    public struct PatchNote
    {
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }

        [JsonProperty(nameof(Details))]
        public string[] Details { get; set; }
    }
}
