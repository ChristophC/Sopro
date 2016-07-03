using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.LinkTables
{
    public class ReadAccessDepartment
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int DepartmentId { get; set; }
        
        public virtual Contract Contract { get; set; }
        public virtual Department Department { get; set; }
    }
}