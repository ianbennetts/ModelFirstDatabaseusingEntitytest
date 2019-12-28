using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Models
{
    public class ParkingSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "This is too long")]
        public string Parm1 { get; set; }
        [MaxLength(100, ErrorMessage = "This is too long")]
        public string Parm2 { get; set; }
        [MaxLength(100, ErrorMessage = "This is too long")]
        public string Parm3 { get; set; }
        [MaxLength(100, ErrorMessage = "This is too long")]
        [Required]
        public string API { get; set; }
        public int? NumberOfSpaces { get; set; }
        public virtual ICollection<SiteArea> SiteAreas { get; set; }
    }
}
