using System.Threading.Tasks;
using DevReady.Core.Models.Hardware;

namespace DevReady.Core.Services.Hardware
{
    public interface IHardwareService
    {
        Task<HardwareInfo> GetHardwareInfoAsync();
    }
}
