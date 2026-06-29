namespace DevReady.Core.Models.Hardware
{
    public class MotherboardInfo
    {
        /// <summary>
        /// Hãng sản xuất bo mạch chủ.
        /// Ví dụ: ASUSTeK COMPUTER INC.
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Tên sản phẩm / Model bo mạch chủ.
        /// Ví dụ: ROG STRIX B550-F GAMING
        /// </summary>
        public string Product { get; set; } = string.Empty;

        /// <summary>
        /// Số sê-ri của bo mạch chủ.
        /// </summary>
        public string SerialNumber { get; set; } = string.Empty;
    }
}
