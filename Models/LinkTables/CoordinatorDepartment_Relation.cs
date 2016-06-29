using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CoordinatorDepartment_Relation
    {
        public int Id { get; set; }
        public string CoordinatorID { get; set; }
        public int DepartmentID { get; set; }

        public virtual ContractUser Coordinator { get; set; }
        public virtual Department Department { get; set; }
    }
}