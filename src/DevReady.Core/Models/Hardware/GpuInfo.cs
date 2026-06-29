namespace DevReady.Core.Models.Hardware
{
    public class GpuInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public double MemoryGB { get; set; }
        public string DriverVersion { get; set; } = string.Empty;
        public bool IsIntegrated { get; set; }
    }
}
