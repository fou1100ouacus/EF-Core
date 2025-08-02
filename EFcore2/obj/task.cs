using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE2
{
    internal class task
    {
        public int id { get; set; }
        public Employee emp { get; set; }
        [Required]
        [Comment("this is comment")]
  
      //  [Index(nameof(name))]
        public string name { get; set; }
        public Employee employee  { get; set; }
        [ForeignKey("empID")]

        public int empID { get; set; }
    }
}
