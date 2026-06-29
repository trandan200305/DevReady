using System;
using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class BiosScanner : IScanner<BiosInfo>
{
    public Task<BiosInfo> ScanAsync()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
        var collection = searcher.Get();

        foreach (ManagementObject bios in collection)
        {
            var info = new BiosInfo
            {
                Manufacturer = bios["Manufacturer"]?.ToString() ?? string.Empty,
                Version = bios["SMBIOSBIOSVersion"]?.ToString() ?? string.Empty,
                ReleaseDate = ParseWmiDate(bios["ReleaseDate"]?.ToString())
            };
            return Task.FromResult(info);
        }

        return Task.FromResult(new BiosInfo());
    }

    private DateTime? ParseWmiDate(string? wmiDate)
    {
        if (string.IsNullOrWhiteSpace(wmiDate)) return null;
        try
        {
            return ManagementDateTimeConverter.ToDateTime(wmiDate);
        }
        catch
        {
            return null;
        }
    }
}
