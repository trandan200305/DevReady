namespace DevReady.Core.Models.Hardware
{
    public class DiskInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double TotalSizeGB { get; set; }
        public double FreeSpaceGB { get; set; }
        public double UsedSpaceGB { get; set; }
        public string FileSystem { get; set; } = string.Empty;
    }
}
