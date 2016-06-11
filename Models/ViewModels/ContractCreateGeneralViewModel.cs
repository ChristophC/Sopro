using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateGeneralViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }

        public int ContractsKindId { get; set; }
        public int ContractsTypeId { get; set; }
        public int ContractSubTypeId { get; set; }
        public string Ext_ContractNr { get; set; }
        public string Remarks { get; set; }
        public int DepartmentId { get; set; }
        public int UDepartmentId { get; set; }

        public IEnumerable<SelectListItem> ContractKinds { get; set; }
        public IEnumerable<SelectListItem> ContractTypes { get; set; }
        public IEnumerable<SelectListItem> ContractSubTypes { get; set; }

        public IEnumerable<SelectListItem> FrameContractChoice { get; set; }
    }
}