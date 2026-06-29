using System;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class RamScanner : IScanner<RamInfo>
{
    public Task<RamInfo> ScanAsync()
    {
        var ramInfo = new RamInfo();
        long totalCapacityBytes = 0;
        int count = 0;
        double speedMhz = 0;
        string type = "Unknown";

        // Lấy thông tin về bộ nhớ vật lý
        using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
        {
            var collection = searcher.Get();
            foreach (ManagementObject mem in collection)
            {
                if (mem["Capacity"] != null)
                {
                    totalCapacityBytes += Convert.ToInt64(mem["Capacity"]);
                }
                
                if (mem["ConfiguredClockSpeed"] != null)
                {
                    speedMhz = Convert.ToDouble(mem["ConfiguredClockSpeed"]);
                }
                
                if (mem["SMBIOSMemoryType"] != null)
                {
                    type = GetMemoryType(Convert.ToInt32(mem["SMBIOSMemoryType"]));
                }
                
                count++;
            }
        }
        
        ramInfo.ModuleCount = count;
        ramInfo.TotalSizeGB = Math.Round(totalCapacityBytes / (1024.0 * 1024 * 1024), 2);
        ramInfo.SpeedMHz = speedMhz;
        ramInfo.Type = type;

        // Lấy thông tin về mức độ sử dụng RAM
        using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
        {
            var collection = searcher.Get();
            foreach (ManagementObject os in collection)
            {
                if (os["FreePhysicalMemory"] != null && os["TotalVisibleMemorySize"] != null)
                {
                    long freeKb = Convert.ToInt64(os["FreePhysicalMemory"]);
                    long totalKb = Convert.ToInt64(os["TotalVisibleMemorySize"]);
                    long usedKb = totalKb - freeKb;
                    
                    ramInfo.AvailableMemoryGB = Math.Round(freeKb / (1024.0 * 1024), 2);
                    ramInfo.UsedMemoryGB = Math.Round(usedKb / (1024.0 * 1024), 2);
                }
                break;
            }
        }

        return Task.FromResult(ramInfo);
    }

    private string GetMemoryType(int type)
    {
        return type switch
        {
            20 => "DDR",
            21 => "DDR2",
            24 => "DDR3",
            26 => "DDR4",
            34 => "DDR5",
            _ => "Unknown"
        };
    }
}
