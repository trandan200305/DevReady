using System;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class GpuScanner : IScanner<GpuInfo>
{
    public Task<GpuInfo> ScanAsync()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
        var collection = searcher.Get();

        foreach (ManagementObject gpu in collection)
        {
            double memoryGb = 0;
            if (gpu["AdapterRAM"] != null && long.TryParse(gpu["AdapterRAM"].ToString(), out long bytes))
            {
                memoryGb = Math.Round(bytes / (1024.0 * 1024 * 1024), 2);
            }

            var name = gpu["Name"]?.ToString() ?? string.Empty;
            
            var info = new GpuInfo
            {
                Name = name,
                Manufacturer = gpu["AdapterCompatibility"]?.ToString() ?? string.Empty,
                MemoryGB = memoryGb,
                DriverVersion = gpu["DriverVersion"]?.ToString() ?? string.Empty,
                IsIntegrated = name.Contains("Intel", StringComparison.OrdinalIgnoreCase) || 
                               name.Contains("AMD Radeon Graphics", StringComparison.OrdinalIgnoreCase)
            };
            return Task.FromResult(info);
        }

        return Task.FromResult(new GpuInfo());
    }
}
