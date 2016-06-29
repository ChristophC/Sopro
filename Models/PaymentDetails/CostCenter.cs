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

        public virtual Client Client { get; set; }
        public virtual ICollection<ContractCostCenter_Relation> ContractCostCenter_Relations { get; set; }

    }
}