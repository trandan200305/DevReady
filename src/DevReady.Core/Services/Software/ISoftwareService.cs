using DevReady.Core.Models.Software;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReady.Core.Services.Software
{
    public interface ISoftwareService
    {
        Task<SoftwareInfo> GetSoftwareInfoAsync();
    }
}
