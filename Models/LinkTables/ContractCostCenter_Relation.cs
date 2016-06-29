using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractCostCenter_Relation
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CostCenterId { get; set; }

        [Range(0, 1)]
        public double Percentage { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual CostCenter CostCenter { get; set; }
    }
}