using System.Collections.Generic;

namespace DevReady.Core.Models.Hardware
{
    public class HardwareInfo
    {
        public CpuInfo Cpu { get; set; } = new CpuInfo();
        public RamInfo Ram { get; set; } = new RamInfo();
        public GpuInfo Gpu { get; set; } = new GpuInfo();
        public List<DiskInfo> Disks { get; set; } = new List<DiskInfo>();
        public MotherboardInfo Motherboard { get; set; } = new MotherboardInfo();
        public BiosInfo Bios { get; set; } = new BiosInfo();
        public OsInfo OperatingSystem { get; set; } = new OsInfo();
        public List<DisplayInfo> Displays { get; set; } = new List<DisplayInfo>();
        public List<NetworkInfo> Networks { get; set; } = new List<NetworkInfo>();
    }
}
