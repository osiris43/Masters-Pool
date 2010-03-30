using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace MastersPool.Core
{
    [Table(Name = "Golfer")]
    public class Golfer : IComparable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column]
        public string FirstName { get; set; }

        [Column]
        public string LastName { get; set; }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public int CompareTo(object obj)
        {
            if(obj is Golfer)
            {
                Golfer golfer2 = obj as Golfer;
                return FirstName.CompareTo(golfer2.FirstName);
            }

            throw new ArgumentException("object is not a Golfer");
        }

    }
}
