using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CostCenter
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual Mandant Mandant { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        
    }
}