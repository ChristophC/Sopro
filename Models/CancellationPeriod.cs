using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CancellationPeriod
    {
        public int Id { get; set; }
        public string Days { get; set; }
        public int Months { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}