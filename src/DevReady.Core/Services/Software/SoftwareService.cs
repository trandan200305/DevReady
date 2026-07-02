using DevReady.Core.Interfaces;
using DevReady.Core.Models.Software;
using System.Threading.Tasks;

namespace DevReady.Core.Services.Software
{
    public class SoftwareService : ISoftwareService
    {
        private readonly IScanner<SoftwareInfo> _softwareScanner;

        public SoftwareService(IScanner<SoftwareInfo> softwareScanner)
        {
            _softwareScanner = softwareScanner;
        }

        public async Task<SoftwareInfo> GetSoftwareInfoAsync()
        {
            return await _softwareScanner.ScanAsync();
        }
    }
}
