using System;

namespace DevReady.Core.Models.Hardware
{
    public class BiosInfo
    {
        /// <summary>
        /// Hãng sản xuất BIOS.
        /// Ví dụ: American Megatrends Inc.
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Phiên bản BIOS.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// Ngày phát hành BIOS.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
    }
}
