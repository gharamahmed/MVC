using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class employee
    {
        [Key]
        public int SSN { get; set; }
        [StringLength(50)]
        public string? Fname{ get; set; }
        [StringLength(50)]
        public string? Minit { get; set; }
        [StringLength(50)]
        public string? Lname { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Bdate { get; set; }
        [StringLength(100)]
        public string? Address{ get; set; }

        [StringLength(100)]
        public string? Gender { get; set; }

        [Column(TypeName = "money")]
        public double? Salary { get; set; }
        [ForeignKey("employee")]
        public int? super { get; set; }
        public List<employee>? supervisor { get; set; }

        public List<works_on>? works_Ons { get; set; } 
        public List<dependent>? dependents { get; set; }

        public department? Department { get; set; }

        public department? Department2 { get; set; }

        [ForeignKey("department")]
        public int? deptid { get; set; }



    }
}
