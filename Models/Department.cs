using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DispatcherId { get; set; }
        public string StvDispatcherId { get; set; }




        public virtual ContractUser Dispatcher { get; set; }
        public virtual ContractUser StvDispatcher { get; set; }
        public virtual Mandant Mandant { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Contract> SupervisorContracts { get; set; }
        public virtual ICollection<PhysicalDocAddress> PhysicalDocAddresses { get; set; }
    }
}