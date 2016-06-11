using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractUser : IdentityUser
    {
        public virtual ICollection<Contract> OwnerContracts { get; set; }
        public virtual ICollection<Contract> DispatcherContracts { get; set; }
        public virtual ICollection<Contract> CoordinatorContracts { get; set; }
        public virtual ICollection<Contract> SignerContracts { get; set; }
        public virtual ICollection<DU_Relation> DU_Realtions { get; set; }
        public virtual ICollection<MU_Relation> MU_Relations { get; set; }
        public virtual ICollection<Department> DispatcherDepartments { get; set; }
        public virtual ICollection<Department> StvDispatcherDepartments { get; set; }
    }
}