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
        public virtual ICollection<Contract> SignerContracts { get; set; }
        public virtual ICollection<ContractTask> OwnerContractTasks { get; set; }
        public virtual ICollection<DepartmentUser_Relation> DepartmentUser_Relations { get; set; }
        public virtual ICollection<CoordinatorClient_Relation> CoordinatorClient_Relations { get; set; }
        public virtual ICollection<Department> DispatcherDepartments { get; set; }
        public virtual ICollection<Department> ViceDispatcherDepartments { get; set; }
        public virtual ICollection<CoordinatorDepartment_Relation> CoordinatorDepartments_Relations { get; set; }
    }
}