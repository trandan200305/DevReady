namespace DevReady.Core.Models.Hardware
{
    public class RamInfo
    {
        /// <summary>
        /// Tổng dung lượng RAM (GB).
        /// </summary>
        public double TotalSizeGB { get; set; }

        /// <summary>
        /// Số thanh RAM đang được lắp.
        /// </summary>
        public int ModuleCount { get; set; }

        /// <summary>
        /// Chuẩn RAM.
        /// Ví dụ: DDR4, DDR5
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Tốc độ Bus của RAM (MHz).
        /// </summary>
        public double SpeedMHz { get; set; }

        /// <summary>
        /// Dung lượng RAM còn trống (GB).
        /// </summary>
        public double AvailableMemoryGB { get; set; }

        /// <summary>
        /// Dung lượng RAM đang sử dụng (GB).
        /// </summary>
        public double UsedMemoryGB { get; set; }
    }
}
