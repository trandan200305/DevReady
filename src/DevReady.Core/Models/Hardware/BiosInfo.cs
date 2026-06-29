using System;

namespace DevReady.Core.Models.Hardware
{
    public class BiosInfo
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
    }
}
