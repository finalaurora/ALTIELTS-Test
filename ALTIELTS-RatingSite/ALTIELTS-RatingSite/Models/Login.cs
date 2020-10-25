using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALTIELTS_RatingSite.Models
{
    public class Login
    {
        [Key]
        public string Token { get; set; }
        public string PassCode { get; set; }
    }
}
