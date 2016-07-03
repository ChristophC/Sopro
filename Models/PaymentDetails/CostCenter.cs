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

        public override bool Equals(object obj)
        {
            var item = obj as CostCenter;
            if (item != null)
            {
                return item.Id == Id;
            }
            return false;
        }

        public static bool operator ==(CostCenter a, CostCenter b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CostCenter a, CostCenter b)
        {
            return !a.Equals(b);
        }
    }
}