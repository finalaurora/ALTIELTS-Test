using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALTIELTS_RatingSite.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PassCode { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
