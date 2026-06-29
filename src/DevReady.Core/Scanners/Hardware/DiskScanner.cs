using System;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class DiskScanner : IScanner<List<DiskInfo>>
{
    public Task<List<DiskInfo>> ScanAsync()
    {
        var disks = new List<DiskInfo>();
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 3");
        var collection = searcher.Get();

        foreach (ManagementObject disk in collection)
        {
            long size = disk["Size"] != null ? Convert.ToInt64(disk["Size"]) : 0;
            long free = disk["FreeSpace"] != null ? Convert.ToInt64(disk["FreeSpace"]) : 0;
            long used = size - free;

            var info = new DiskInfo
            {
                Name = disk["Name"]?.ToString() ?? string.Empty,
                FileSystem = disk["FileSystem"]?.ToString() ?? string.Empty,
                Type = "Local Disk",
                TotalSizeGB = Math.Round(size / (1024.0 * 1024 * 1024), 2),
                FreeSpaceGB = Math.Round(free / (1024.0 * 1024 * 1024), 2),
                UsedSpaceGB = Math.Round(used / (1024.0 * 1024 * 1024), 2)
            };
            
            disks.Add(info);
        }

        return Task.FromResult(disks);
    }
}
