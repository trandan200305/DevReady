namespace DevReady.Core.Interfaces;

using DevReady.Core.Models.Hardware;

public interface IHardwareService
{
    Task<HardwareInfo> ScanHardwareAsync();
}