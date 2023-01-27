using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class department
    {
        [Key]
        public int? Number { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? startdate { get; set; }

        public int? employeeSSN { get; set; } 

        public List<locations>? locations { get; set; }
        public List<project>? projects { get; set; }
        public employee? employee { get; set; }
        public List<employee>? employees { get; set; }

    }
}
