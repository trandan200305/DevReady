using System.Collections.Generic;

namespace DevReady.Core.Models.Hardware
{
    public class HardwareInfo
    {
        /// <summary>
        /// Thông tin CPU.
        /// </summary>
        public CpuInfo Cpu { get; set; } = new CpuInfo();

        /// <summary>
        /// Thông tin RAM.
        /// </summary>
        public RamInfo Ram { get; set; } = new RamInfo();

        /// <summary>
        /// Thông tin Card đồ họa (GPU).
        /// </summary>
        public GpuInfo Gpu { get; set; } = new GpuInfo();

        /// <summary>
        /// Danh sách các ổ đĩa lưu trữ.
        /// </summary>
        public List<DiskInfo> Disks { get; set; } = new List<DiskInfo>();

        /// <summary>
        /// Thông tin Bo mạch chủ (Mainboard/Motherboard).
        /// </summary>
        public MotherboardInfo Motherboard { get; set; } = new MotherboardInfo();

        /// <summary>
        /// Thông tin BIOS.
        /// </summary>
        public BiosInfo Bios { get; set; } = new BiosInfo();

        /// <summary>
        /// Thông tin Hệ điều hành (OS).
        /// </summary>
        public OsInfo OperatingSystem { get; set; } = new OsInfo();

        /// <summary>
        /// Danh sách màn hình.
        /// </summary>
        public List<DisplayInfo> Displays { get; set; } = new List<DisplayInfo>();

        /// <summary>
        /// Danh sách các card mạng (Networks).
        /// </summary>
        public List<NetworkInfo> Networks { get; set; } = new List<NetworkInfo>();
    }
}
