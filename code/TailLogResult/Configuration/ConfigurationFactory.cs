using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Configuration
{
    public static class ConfigurationFactory
    {
        private static IConfiguration _configuration;

        private static IConfiguration GetConfiguration()
        {
            if(null == _configuration)
            {
                _configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();                
            }
            return _configuration;
        }
        public static ProgramParameters GetParameters()
        {
            var config = GetConfiguration();
            return config.Get<ProgramParameters>();
           
        }
    }
}
