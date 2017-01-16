using System.Collections.Generic;

namespace SchoolBusCommon
{
    public class ApplicationVersionInfo : VersionInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public string Commit { get; set; }
        public string FileVersion { get; set; }
        public string FileCreationTime { get; set; }
        public string InformationalVersion { get; set; }
        public string TargetFramework { get; set; }
        public string ImageRuntimeVersion { get; set; }
        public IEnumerable<VersionInfo> Dependancies { get; set; }
    }
}
