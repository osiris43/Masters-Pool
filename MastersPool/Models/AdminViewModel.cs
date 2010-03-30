using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MastersPool.Core;

namespace MastersPool.Models
{
    public class AdminViewModel
    {
        public int CurrentYear { get; set; }
        public string Message { get; set; }
        public List<GolferSectionViewModel> GolferSections { get; set; }
    }
}
