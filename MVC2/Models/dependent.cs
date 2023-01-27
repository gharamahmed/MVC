using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class dependent
    {
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Sex { get; set; }
        [Column(TypeName ="date")]
        public DateTime? Birthdate{ get; set; }
        public string? Relationship { get; set; }

        [ForeignKey("Employee")]
        public int? ESSN { get; set; }
        public employee?Employee { get; set; }
    }
}
