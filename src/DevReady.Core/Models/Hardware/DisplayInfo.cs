namespace DevReady.Core.Models.Hardware
{
    public class DisplayInfo
    {
        /// <summary>
        /// Tên màn hình.
        /// Ví dụ: Generic PnP Monitor
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Độ phân giải màn hình.
        /// Ví dụ: 1920x1080
        /// </summary>
        public string Resolution { get; set; } = string.Empty;

        /// <summary>
        /// Tần số quét (Hz).
        /// Ví dụ: 60, 144
        /// </summary>
        public int RefreshRateHz { get; set; }
    }
}
