using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractPartner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double IBAN { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}