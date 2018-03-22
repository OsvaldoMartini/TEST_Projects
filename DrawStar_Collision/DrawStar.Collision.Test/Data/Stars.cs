using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawStars.Data
{
    [Table("TblStar")]
    class Stars
    {
        [Key]
        public int StarId { get; set; }
        public string StartName { get; set; }
        public virtual ICollection<StarsPoints> StarPoints { get; set; }
    }
}
