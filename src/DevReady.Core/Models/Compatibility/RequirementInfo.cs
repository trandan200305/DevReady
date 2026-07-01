namespace DevReady.Core.Models.Compatibility
{
    public class RequirementInfo
    {
        public string ApplicationName { get; set; } = string.Empty;

        public int MinimumCpuCores { get; set; }

        public int MinimumRamGB { get; set; }

        public int MinimumDiskGB { get; set; }

        public string MinimumGpu { get; set; } = string.Empty;

        public string RequiredOperatingSystem { get; set; } = string.Empty;

        public string RequiredDotNetVersion { get; set; } = string.Empty;
    }
}
