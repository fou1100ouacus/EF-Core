using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE2
{
    internal class Employee
    {

        public int id { get; set; }
        [Column(TypeName ="varchar(200)")]
        public string name { get; set; }
        [Required]
        [MaxLength(50)]
        public string email { get; set; }
       [NotMapped]
        public List<task> task { get; set; }


    }
}
