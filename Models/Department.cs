using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DispatcherId { get; set; }
        public string ViceDispatcherId { get; set; }
        

        public virtual ContractUser Dispatcher { get; set; }
        public virtual ContractUser ViceDispatcher { get; set; }
        
        public virtual Client Client { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Contract> SupervisorContracts { get; set; }
        public virtual ICollection<PhysicalDocAddress> PhysicalDocAddresses { get; set; }
        public virtual ICollection<CoordinatorDepartment_Relation> CoordinatorDepartment_Relations { get; set; }
    }
}