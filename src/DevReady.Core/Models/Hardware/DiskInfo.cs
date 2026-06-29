namespace DevReady.Core.Models.Hardware
{
    public class DiskInfo
    {
        /// <summary>
        /// Tên ổ đĩa hoặc nhãn.
        /// Ví dụ: C:, D:, NVMe Samsung
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Loại ổ đĩa.
        /// Ví dụ: SSD, HDD, NVMe
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Tổng dung lượng ổ đĩa (GB).
        /// </summary>
        public double TotalSizeGB { get; set; }

        /// <summary>
        /// Dung lượng trống (GB).
        /// </summary>
        public double FreeSpaceGB { get; set; }

        /// <summary>
        /// Dung lượng đã sử dụng (GB).
        /// </summary>
        public double UsedSpaceGB { get; set; }

        /// <summary>
        /// Định dạng hệ thống tập tin.
        /// Ví dụ: NTFS, FAT32
        /// </summary>
        public string FileSystem { get; set; } = string.Empty;
    }
}
