using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateCostsViewModel
    {
    //● ContractValue(Checkbox) TextBox
    //○ AnnualValue(Checkbox) TextBox
    //● PaymentIntervall TextBox
    //(Monate)
    //● Adaptable CheckBox
    //● Prepayable CheckBox
    //○ VarPayable CheckBox
    //● Tax SchiebeRegler
    //● CostCenter DropDown

        public int ContractId { get; set; }
        [DisplayName("Vertragswert")] //4.11
        public Nullable<double> ContractValue { get; set; }
        [DisplayName("Kosten/Gsft-Jahr")] //4.12 ??
        public Nullable<double> AnnualValue { get; set; }
        [DisplayName("Zahlungsbeginn")] //4.14
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> PaymentBegin { get; set; }
        [DisplayName("Zahlungsintervall")] //4.15
        public Nullable<int> PaymentInterval { get; set; }
        [DisplayName("MwSt")] //4.27
        //Characteristics
        public Nullable<double> Tax { get; set; }
        [DisplayName("Im Voraus zahlbar")]
        public bool PrePayable { get; set; }
        [DisplayName("Variable Kosten")]
        public bool VarPayable { get; set; }
        [DisplayName("Zulassung von Preisanpassung")]
        public bool Adaptable { get; set; }

        [DisplayName("Kostenstelle(n)")] //4.16
        public List<Nullable<int>> CostCenterIds { get; set; }
        [DisplayName("Kostenstelle(n)")] //4.16
        public List<ContractCostCenter_Relation> ContractCostCenter_Relations { get; set; }
        public List<IEnumerable<SelectListItem>> CostCenterSelectLists { get; set; }
        public List<double?> CostCenterPercentages { get; set; }
        public int? CostCenterIndex { get; set; } //is needed to delete CostCenter from Lists
        [DisplayName("Kostenart")] //4.17
        public int? CostKindId { get; set; }

        //Contract only used by RightForm
        public Contract Contract { get; set; }

        
        public IEnumerable<SelectListItem> CostKinds { get; set; }

        public int? CostCenterClientId { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }
    }
}