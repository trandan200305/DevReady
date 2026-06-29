using System;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class NetworkScanner : IScanner<List<NetworkInfo>>
{
    public Task<List<NetworkInfo>> ScanAsync()
    {
        var networks = new List<NetworkInfo>();
        // Chỉ lấy các Network Adapter vật lý
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = true");
        var collection = searcher.Get();

        foreach (ManagementObject adapter in collection)
        {
            if (adapter["MACAddress"] == null) continue;

            double speedMbps = 0;
            if (adapter["Speed"] != null && long.TryParse(adapter["Speed"].ToString(), out long speed))
            {
                speedMbps = Math.Round(speed / 1000000.0, 2);
            }
            
            bool isConnected = false;
            if (adapter["NetConnectionStatus"] != null)
            {
                // Trạng thái 2 nghĩa là đang kết nối
                isConnected = Convert.ToInt32(adapter["NetConnectionStatus"]) == 2;
            }

            var info = new NetworkInfo
            {
                AdapterName = adapter["Name"]?.ToString() ?? string.Empty,
                MacAddress = adapter["MACAddress"]?.ToString() ?? string.Empty,
                LinkSpeedMbps = speedMbps,
                IsConnected = isConnected
            };
            
            networks.Add(info);
        }

        return Task.FromResult(networks);
    }
}
