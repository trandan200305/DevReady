namespace DevReady.Core.Models.Hardware
{
    public class RamInfo
    {
        public double TotalSizeGB { get; set; }
        public int ModuleCount { get; set; }
        public string Type { get; set; } = string.Empty;
        public double SpeedMHz { get; set; }
        public double AvailableMemoryGB { get; set; }
        public double UsedMemoryGB { get; set; }
    }
}
