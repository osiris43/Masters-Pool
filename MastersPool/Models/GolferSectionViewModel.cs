using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MastersPool.Core;

namespace MastersPool.Models
{
    public class GolferSectionViewModel
    {
        public List<Golfer> Golfers { get; set; }
        public string SectionHeader { get; set; }
    }
}
