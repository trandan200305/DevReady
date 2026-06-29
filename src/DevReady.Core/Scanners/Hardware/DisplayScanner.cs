using System;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class DisplayScanner : IScanner<List<DisplayInfo>>
{
    public Task<List<DisplayInfo>> ScanAsync()
    {
        var displays = new List<DisplayInfo>();
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
        var collection = searcher.Get();

        foreach (ManagementObject monitor in collection)
        {
            // Bỏ qua nếu không lấy được độ phân giải (có thể không phải màn hình đang active)
            if (monitor["CurrentHorizontalResolution"] == null || monitor["CurrentVerticalResolution"] == null)
            {
                continue;
            }

            var horizontal = monitor["CurrentHorizontalResolution"]?.ToString();
            var vertical = monitor["CurrentVerticalResolution"]?.ToString();
            
            int refreshRate = 0;
            if (monitor["CurrentRefreshRate"] != null)
            {
                refreshRate = Convert.ToInt32(monitor["CurrentRefreshRate"]);
            }

            var info = new DisplayInfo
            {
                Name = monitor["Name"]?.ToString() ?? monitor["Description"]?.ToString() ?? "Generic Monitor",
                Resolution = $"{horizontal}x{vertical}",
                RefreshRateHz = refreshRate
            };
            
            displays.Add(info);
        }

        return Task.FromResult(displays);
    }
}
