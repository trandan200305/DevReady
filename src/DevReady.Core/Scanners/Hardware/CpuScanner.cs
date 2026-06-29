using System.Management;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class CpuScanner : IScanner<CpuInfo>
{
    public Task<CpuInfo> ScanAsync()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

        var collection = searcher.Get();

        foreach (ManagementObject cpu in collection)
        {
            var cpuInfo = new CpuInfo
            {
                Name = cpu["Name"]?.ToString() ?? string.Empty,

                Manufacturer = cpu["Manufacturer"]?.ToString() ?? string.Empty,

                CoreCount = Convert.ToInt32(cpu["NumberOfCores"] ?? 0),

                ThreadCount = Convert.ToInt32(cpu["NumberOfLogicalProcessors"] ?? 0),

                BaseClockMHz = Convert.ToInt32(cpu["CurrentClockSpeed"] ?? 0),

                MaxClockMHz = Convert.ToInt32(cpu["MaxClockSpeed"] ?? 0),

                ProcessorId = cpu["ProcessorId"]?.ToString() ?? string.Empty,

                VirtualizationEnabled = Convert.ToBoolean(
                    cpu["VirtualizationFirmwareEnabled"] ?? false),

                Architecture = GetArchitecture(
                    Convert.ToUInt16(cpu["Architecture"] ?? 0))
            };

            return Task.FromResult(cpuInfo);
        }

        throw new InvalidOperationException("Không tìm thấy thông tin CPU.");
    }

    private string GetArchitecture(ushort architecture)
    {
        return architecture switch
        {
            0 => "x86",
            5 => "ARM",
            6 => "Intel Itanium",
            9 => "x64",
            12 => "ARM64",
            _ => "Unknown"
        };
    }
}