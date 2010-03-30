using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace MastersPool.Data
{
    public class Database : DataContext
    {
        public Database(string connection) :
            base(connection)
        {
        }
    }
}
