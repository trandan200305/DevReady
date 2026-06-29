using System.Management;
using System.Threading.Tasks;
using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Scanners.Hardware;

public class OsScanner : IScanner<OsInfo>
{
    public Task<OsInfo> ScanAsync()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        var collection = searcher.Get();

        foreach (ManagementObject os in collection)
        {
            string architecture = os["OSArchitecture"]?.ToString() ?? string.Empty;
            
            var info = new OsInfo
            {
                Name = os["Caption"]?.ToString() ?? string.Empty,
                Version = os["Version"]?.ToString() ?? string.Empty,
                BuildNumber = os["BuildNumber"]?.ToString() ?? string.Empty,
                Architecture = architecture,
                Is64Bit = architecture.Contains("64")
            };
            return Task.FromResult(info);
        }

        return Task.FromResult(new OsInfo());
    }
}
