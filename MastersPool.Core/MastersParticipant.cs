using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace MastersPool.Core
{
    [Table(Name="MastersParticipant")]
    public class MastersParticipant
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column]
        public int MastersYearId { get; set; }

        [Column]
        public int GolferId { get; set; }

        [Column]
        public int MoneyGroup { get; set; }

        [Association(Name="FK_Year_Participant", Storage = "mastersYear", IsForeignKey = true, 
            ThisKey = "MastersYearId", OtherKey = "Id")]
        public MastersYear MastersYear
        {
            get
            {
                return this.mastersYear.Entity;
            }
            set
            {
                this.mastersYear.Entity = value;
            }
        }

        [Association(Name = "FK_Golfer_Participant", Storage = "golfer", IsForeignKey = true,
            ThisKey = "GolferId", OtherKey = "Id")]
        public Golfer Golfer 
        {
            get
            {
                return this.golfer.Entity;
            }
            set
            {
                this.golfer.Entity = value;
            }
        }

        private EntityRef<MastersYear> mastersYear;
        private EntityRef<Golfer> golfer;
    }
}
