using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;
using WebApplication1.Models;

namespace WebApplication1.Models.ViewModels.Contract
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class ContractExportViewModel
    {
        [FieldOrder(1), FieldTitle("Int. VertragsNr.")]
        public string IntContractNum { get; set; }
        [FieldOrder(2), FieldTitle ("Ext. VertragsNr")]
        public string ExtContractNum { get; set; }
        [FieldOrder(3), FieldTitle ("Vertragsgegenstand")]
        public string Description { get; set; }
        [FieldOrder(4), FieldTitle ("Unterzeichner")]
        public string Signer { get; set; }
        [FieldOrder(5), FieldTitle ("Sachlich Verantwortlicher")]
        public string Owner { get; set; }
        [FieldOrder(6), FieldTitle ("Zugeordnete Abt.")]
        public string Department { get; set; }
        [FieldOrder(7), FieldTitle ("Überwachende Abt.")]
        public string SupervisorDepartment { get; set; }


        private ContractExportViewModel()
        {
        }


        public ContractExportViewModel(WebApplication1.Models.Contract c)
        {
            IntContractNum = c.IntContractNum;
            ExtContractNum = c.ExtContractNum;
            Description = c.Description;
            Signer = c.Signer.UserName;
            Owner = c.Owner.UserName;
            Department = c.Department.DepartmentName;
            SupervisorDepartment = c.SupervisorDepartment.DepartmentName;
        }
    }
}