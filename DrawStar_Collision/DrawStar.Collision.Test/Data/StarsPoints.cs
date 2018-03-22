using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawStars.Data
{
    [Table("TblStarPoints")]
    class StarsPoints
    {
        [Key] public int StartPointId { get; set; }
        public int Distance { get; set; }

        public int Altitude { get; set; }
        public int Longitude { get; set; }
        public virtual Stars Star { get; set; }
        [ForeignKey("FkStarId")]
        public int FkStarId { get; set; }
    }
}
