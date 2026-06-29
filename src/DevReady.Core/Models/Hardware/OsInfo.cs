namespace DevReady.Core.Models.Hardware
{
    public class OsInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string BuildNumber { get; set; } = string.Empty;
        public string Architecture { get; set; } = string.Empty;
        public bool Is64Bit { get; set; }
    }
}
