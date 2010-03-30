using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace MastersPool.Core
{
    [Table(Name="MastersConfiguration")]
    public class MastersConfiguration
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column]
        public string ConfigKey { get; set; }

        [Column]
        public string ConfigValue { get; set; }

    }
}
