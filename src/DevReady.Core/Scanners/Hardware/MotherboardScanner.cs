using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class MotherboardScanner : IScanner<MotherboardInfo>
{
    public Task<MotherboardInfo> ScanAsync()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        var collection = searcher.Get();

        foreach (ManagementObject board in collection)
        {
            var info = new MotherboardInfo
            {
                Manufacturer = board["Manufacturer"]?.ToString() ?? string.Empty,
                Product = board["Product"]?.ToString() ?? string.Empty,
                SerialNumber = board["SerialNumber"]?.ToString() ?? string.Empty
            };
            return Task.FromResult(info);
        }

        return Task.FromResult(new MotherboardInfo());
    }
}
