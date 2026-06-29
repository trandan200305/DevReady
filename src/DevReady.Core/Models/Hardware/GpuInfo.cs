namespace DevReady.Core.Models.Hardware
{
    public class GpuInfo
    {
        /// <summary>
        /// Tên đầy đủ của GPU.
        /// Ví dụ: NVIDIA GeForce RTX 3060
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Hãng sản xuất GPU.
        /// Ví dụ: NVIDIA, AMD, Intel
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Dung lượng VRAM (GB).
        /// </summary>
        public double MemoryGB { get; set; }

        /// <summary>
        /// Phiên bản Driver hiện tại đang cài đặt.
        /// </summary>
        public string DriverVersion { get; set; } = string.Empty;

        /// <summary>
        /// Xác định GPU là card tích hợp (Onboard) hay card rời.
        /// </summary>
        public bool IsIntegrated { get; set; }
    }
}
