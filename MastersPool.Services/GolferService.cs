using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MastersPool.Services.Interfaces;
using MastersPool.Core;
using MastersPool.Data.Interfaces;

namespace MastersPool.Services
{
    public class GolferService : IGolferService
    {
        public GolferService(ISessionRepository sr)
        {
            this.sessionRepository = sr;
        }

        public List<Golfer> GetAllGolfers()
        {
            return this.sessionRepository.Select<Golfer>();
        }

        public List<MastersParticipant> GetMastersParticipantsByYear(int year)
        {
            return this.sessionRepository.Select<MastersParticipant>(mp => mp.MastersYear.Year == year);
        }

        private ISessionRepository sessionRepository = null;
    }
}
