namespace DevReady.Core.Models.Hardware
{
    public class CpuInfo
    {
        /// <summary>
        /// Tên đầy đủ của CPU.
        /// Ví dụ: Intel(R) Core(TM) i7-12700H
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Hãng sản xuất.
        /// Ví dụ: Intel, AMD
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Số nhân vật lý.
        /// </summary>
        public int CoreCount { get; set; }

        /// <summary>
        /// Số luồng xử lý.
        /// </summary>
        public int ThreadCount { get; set; }

        /// <summary>
        /// Xung nhịp cơ bản (MHz).
        /// </summary>
        public int BaseClockMHz { get; set; }

        /// <summary>
        /// Xung nhịp tối đa (MHz).
        /// </summary>
        public int MaxClockMHz { get; set; }

        /// <summary>
        /// Kiến trúc CPU.
        /// Ví dụ: x64, ARM64
        /// </summary>
        public string Architecture { get; set; } = string.Empty;

        /// <summary>
        /// CPU có bật Virtualization hay không.
        /// </summary>
        public bool VirtualizationEnabled { get; set; }

        /// <summary>
        /// Mã định danh của CPU.
        /// </summary>
        public string ProcessorId { get; set; } = string.Empty;
    }
}