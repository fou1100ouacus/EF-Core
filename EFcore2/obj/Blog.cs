using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE2
{
    internal class Blog
    {
        public int Id { get; set; }
        public string url { get; set; }

        public List<post> post { get; set; }
    }
}
