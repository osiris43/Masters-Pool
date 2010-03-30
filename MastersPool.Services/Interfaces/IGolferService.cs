using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MastersPool.Core;

namespace MastersPool.Services.Interfaces
{
    public interface IGolferService
    {
        List<Golfer> GetAllGolfers();
        List<MastersParticipant> GetMastersParticipantsByYear(int year);
    }
}
