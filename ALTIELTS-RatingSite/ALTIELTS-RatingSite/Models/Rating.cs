using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALTIELTS_RatingSite.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int DeptId { get; set; }

        public int QuestionNo { get; set; }

        public int Point { get; set; }

        public string Comment { get; set; }

        public DateTime DateTime { get; set; }
    }
}
