using System;
using Microsoft.Extensions.Configuration;

namespace SchoolBusCommon
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
