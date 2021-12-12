using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.ApiIntegration
{
    public interface IApiIntegrationService
    {
        Task IntegrateCountriesAsync();
    }
}
