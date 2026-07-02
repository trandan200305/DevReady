using DevReady.Core.Interfaces;
using DevReady.Core.Models.Software;
using Microsoft.Win32;

namespace DevReady.Core.Scanners.Software;

public class InstalledSoftwareScanner : IScanner<SoftwareInfo>
{
    private const string UninstallRegistryPath =
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

    private const string Wow6432RegistryPath =
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

    public Task<SoftwareInfo> ScanAsync()
    {
        SoftwareInfo softwareInfo = new();

        softwareInfo.InstalledSoftwares.AddRange(
            ReadRegistry(UninstallRegistryPath));

        softwareInfo.InstalledSoftwares.AddRange(
            ReadRegistry(Wow6432RegistryPath));

        return Task.FromResult(softwareInfo);
    }

    private List<InstalledSoftware> ReadRegistry(string registryPath)
    {
        List<InstalledSoftware> softwares = new();

        RegistryKey? uninstallKey =
            Registry.LocalMachine.OpenSubKey(registryPath);

        if (uninstallKey == null)
        {
            return softwares;
        }

        string[] subKeyNames = uninstallKey.GetSubKeyNames();

        foreach (string subKeyName in subKeyNames)
        {
            RegistryKey? softwareKey = uninstallKey.OpenSubKey(subKeyName);

            if (softwareKey == null)
            {
                continue;
            }

            string? name =
                softwareKey.GetValue("DisplayName")?.ToString();

            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            string? version =
                softwareKey.GetValue("DisplayVersion")?.ToString();

            string? publisher =
                softwareKey.GetValue("Publisher")?.ToString();

            string? installLocation =
                softwareKey.GetValue("InstallLocation")?.ToString();

            string? uninstallCommand =
                softwareKey.GetValue("UninstallString")?.ToString();

            InstalledSoftware software = new()
            {
                Name = name,
                Version = version ?? string.Empty,
                Publisher = publisher ?? string.Empty,
                InstallLocation = installLocation ?? string.Empty,
                UninstallCommand = uninstallCommand ?? string.Empty,
                InstallDate = null
            };

            softwares.Add(software);
        }

        return softwares;
    }
}