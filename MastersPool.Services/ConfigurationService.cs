using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MastersPool.Services.Interfaces;
using MastersPool.Core;
using MastersPool.Data.Interfaces;

namespace MastersPool.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public ConfigurationService(ISessionRepository sr)
        {
            this.sessionRepository = sr;
        }

        public List<MastersConfiguration> GetAllConfiguration()
        {
            throw new NotImplementedException();
        }

        public MastersConfiguration GetConfigurationByKey(string key)
        {
            return this.sessionRepository.SelectSingle<MastersConfiguration>(mc => mc.ConfigKey == key); 
        }

        public void ConvertYear()
        {
            MastersConfiguration currentYear =
                this.sessionRepository.SelectSingle<MastersConfiguration>(mc => mc.ConfigKey == "CurrentYear");
            MastersYear year = new MastersYear {Year = Convert.ToInt32(currentYear.ConfigValue) + 1};
            currentYear.ConfigValue = year.Year.ToString();

            this.sessionRepository.Save(year);
            this.sessionRepository.SubmitChanges();
        }

        private ISessionRepository sessionRepository = null;
    }
}
