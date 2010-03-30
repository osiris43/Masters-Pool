using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MastersPool.Core;

namespace MastersPool.Services.Interfaces
{
    public interface IConfigurationService
    {
        List<MastersConfiguration> GetAllConfiguration();
        MastersConfiguration GetConfigurationByKey(string key);
        void ConvertYear();
        
    }
}
