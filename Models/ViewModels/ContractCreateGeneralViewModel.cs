using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateGeneralViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }

        public int ContractsKindId { get; set; }
        public int ContractsTypeId { get; set; }
        public int ContractSubTypeId { get; set; }
        [DisplayName("Ext. VertragNr")]
        public string Ext_ContractNr { get; set; }
        [DisplayName("Bemerkungen")]
        public string Remarks { get; set; }
        [DisplayName("Zugeordnete Abteilung")]
        public int DepartmentId { get; set; }
        [DisplayName("Überwachende Abteilung")]
        public int SuperVisorDepartmentId { get; set; }
        [DisplayName("Ablageort des Vertrags")]
        public int PhysicalDocAdressId { get; set; }
        //Contract Partner Setup
        [DisplayName("Vertragspartner")]
        public int ContractPartnerId { get; set; }
        public string PartnerIBAN { get; set; }
        public string PartnerName { get; set; }


        public IEnumerable<SelectListItem> ContractKinds { get; set; }
        public IEnumerable<SelectListItem> ContractTypes { get; set; }
        public IEnumerable<SelectListItem> ContractSubTypes { get; set; }
       
        //Christoph: Chooses the options for the Frame contracts
        public string FrameOptionChosen { get; set; }
        public string MainFrameIdSelected { get; set; }
        public IEnumerable<SelectListItem> FrameContractChoice { get; set; }
        public IEnumerable<SelectListItem> MainFrameContracts { get; set; }

        public virtual ContractPartner ContractPartner { get; set; }
    }
}