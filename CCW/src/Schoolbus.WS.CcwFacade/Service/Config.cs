using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public class Config
    {
        private readonly IConfiguration _configuration;

        public Config (IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public Config ()
        {

        }

        public bool UseFakeServices
        {
            get
            {
                // restrict option so it won't accidentally be used on production
#if DEBUG
                bool result = false;
                if (_configuration != null)
                { 
                    result = Boolean.Parse(_configuration["UseFakeServices"]);
                }
                return result;
#else
                    return false;
#endif
            }
        }
    }
}
