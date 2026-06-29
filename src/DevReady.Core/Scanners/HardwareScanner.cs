using DevReady.Core.Scanners.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReady.Core.Scanners
{
    public class HardwareScanner
    {
        private readonly CpuScanner _cpuScanner;
        // sau khi hoàn thiện các scanner khác, có thể thêm vào đây

        public HardwareScanner()
        {
            _cpuScanner = new CpuScanner();
        }
    }
}
