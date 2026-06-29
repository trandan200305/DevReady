namespace DevReady.Core.Models.Hardware
{
    public class NetworkInfo
    {
        /// <summary>
        /// Tên card mạng.
        /// Ví dụ: Intel(R) Wi-Fi 6 AX200 160MHz
        /// </summary>
        public string AdapterName { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ MAC của card mạng.
        /// </summary>
        public string MacAddress { get; set; } = string.Empty;

        /// <summary>
        /// Tốc độ kết nối (Mbps).
        /// </summary>
        public double LinkSpeedMbps { get; set; }

        /// <summary>
        /// Trạng thái kết nối.
        /// </summary>
        public bool IsConnected { get; set; }
    }
}
