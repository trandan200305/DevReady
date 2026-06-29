namespace DevReady.Core.Models.Hardware
{
    public class OsInfo
    {
        /// <summary>
        /// Tên hệ điều hành.
        /// Ví dụ: Microsoft Windows 11 Pro
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Phiên bản hệ điều hành.
        /// Ví dụ: 10.0.22621
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// Mã bản dựng (Build Number).
        /// Ví dụ: 22621
        /// </summary>
        public string BuildNumber { get; set; } = string.Empty;

        /// <summary>
        /// Kiến trúc hệ điều hành.
        /// Ví dụ: 64-bit
        /// </summary>
        public string Architecture { get; set; } = string.Empty;

        /// <summary>
        /// Hệ điều hành có phải là 64-bit không.
        /// </summary>
        public bool Is64Bit { get; set; }
    }
}
