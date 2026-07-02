using System;

namespace DevReady.Core.Models.Software
{
    public class InstalledSoftware
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string InstallLocation { get; set; } = string.Empty;
        public string UninstallCommand { get; set; } = string.Empty;
        public DateTime? InstallDate { get; set; }
    }
}
