using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace MastersPool.Core
{
    [Table(Name = "MastersYear")]
    public class MastersYear
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column]
        public int Year { get; set; }
    }
}
