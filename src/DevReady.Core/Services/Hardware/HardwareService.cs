using DevReady.Core.Interfaces;
using DevReady.Core.Models.Hardware;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReady.Core.Services.Hardware
{

    public class HardwareService : IHardwareService
    {
        private readonly IScanner<CpuInfo> _cpuScanner;
        private readonly IScanner<RamInfo> _ramScanner;
        private readonly IScanner<GpuInfo> _gpuScanner;
        private readonly IScanner<List<DiskInfo>> _diskScanner;
        private readonly IScanner<MotherboardInfo> _motherboardScanner;
        private readonly IScanner<BiosInfo> _biosScanner;
        private readonly IScanner<OsInfo> _osScanner;
        private readonly IScanner<List<DisplayInfo>> _displayScanner;
        private readonly IScanner<List<NetworkInfo>> _networkScanner;


        public HardwareService(
            IScanner<CpuInfo> cpuScanner,
            IScanner<RamInfo> ramScanner,
            IScanner<GpuInfo> gpuScanner,
            IScanner<List<DiskInfo>> diskScanner,
            IScanner<MotherboardInfo> motherboardScanner,
            IScanner<BiosInfo> biosScanner,
            IScanner<OsInfo> osScanner,
            IScanner<List<DisplayInfo>> displayScanner,
            IScanner<List<NetworkInfo>> networkScanner)
        {
            _cpuScanner = cpuScanner;
            _ramScanner = ramScanner;
            _gpuScanner = gpuScanner;
            _diskScanner = diskScanner;
            _motherboardScanner = motherboardScanner;
            _biosScanner = biosScanner;
            _osScanner = osScanner;
            _displayScanner = displayScanner;
            _networkScanner = networkScanner;
        }
        public async Task<HardwareInfo> GetHardwareInfoAsync()
        {
            // Start all scanners concurrently
            var cpuTask = _cpuScanner.ScanAsync();
            var ramTask = _ramScanner.ScanAsync();
            var gpuTask = _gpuScanner.ScanAsync();
            var disksTask = _diskScanner.ScanAsync();
            var motherboardTask = _motherboardScanner.ScanAsync();
            var biosTask = _biosScanner.ScanAsync();
            var osTask = _osScanner.ScanAsync();
            var displaysTask = _displayScanner.ScanAsync();
            var networksTask = _networkScanner.ScanAsync();

            // Wait for all scanners to finish
            await Task.WhenAll(
                cpuTask, ramTask, gpuTask, disksTask, 
                motherboardTask, biosTask, osTask, 
                displaysTask, networksTask
            );

            // Return the aggregated hardware info
            return new HardwareInfo
            {
                Cpu = await cpuTask,
                Ram = await ramTask,
                Gpu = await gpuTask,
                Disks = await disksTask,
                Motherboard = await motherboardTask,
                Bios = await biosTask,
                OperatingSystem = await osTask,
                Displays = await displaysTask,
                Networks = await networksTask
            };
        }
    }
}