using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SchoolBusCommon
{
    public class Config
    {
        private readonly IConfiguration _configuration;

        public Config (IConfiguration configuration)
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
                return Boolean.Parse(_configuration["UseFakeServices"]);
#else
                    return false;
#endif
            }
        }
    }
}
