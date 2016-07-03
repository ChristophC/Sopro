using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateGeneralViewModel
    {
        //Id
        //ExtContractNum
        //● ContractKind DropdownList
        //● ContractTypes DropdownList
        //○ Subtype DropdownList
        //● Abteilung DropdownList
        //● SupervisionAbteilung DropdownList
        //● Ext.ContractNr . TextBox
        //● Remarks TextField
        //(gros)
        //● Phys.Adresse TextSuche
        ///Dropdown
        //● ContractPartner Textsuche
        ///Dropdown
        //○ IBAN TextBox
        //○ Name TextBox

        public int ContractId { get; set; }
        [DisplayName("Ext. VertragNr")] //4.2 Pflicht
        public string ExtContractNum { get; set; }
        [DisplayName("Vertragsart")]
        public int? ContractKindId { get; set; }
        [DisplayName("Vertragskategorie")]
        public int? ContractTypeId { get; set; }
        [DisplayName("Unterkategorie")]
        public int? ContractSubTypeId { get; set; }
        /*[DisplayName("Ext. VertragNr")]
        public string Ext_ContractNr { get; set; }*///Is in Files
        [DisplayName("Bemerkungen")]
        public string Remarks { get; set; }
        [DisplayName("Zugeordnete Abteilung")]
        public int? DepartmentId { get; set; }
        [DisplayName("Überwachende Abteilung")]
        public int? SupervisorDepartmentId { get; set; }
        [DisplayName("Ablageort des Vertrags")]
        public int? PhysicalDocAdressId { get; set; }
        [DisplayName("Vertragsabteilung")]
        public int? PDA_DepartmentId { get; set; }
        [DisplayName("Raum")]
        public string PDA_Room { get; set; }
        [DisplayName("Adresse")]
        public string PDA_Adress { get; set; }
        //Contract Partner Setup
        [DisplayName("Vertragspartner")]
        public int? ContractPartnerId { get; set; }
        public IEnumerable<SelectListItem> ContractPartners { get; set; }
        [DisplayName("IBAN"), RegularExpression(  @"[a-zA-Z]{2}[0-9]{2}[a-zA-Z0-9]{4}[0-9]{7}([a-zA-Z0-9]?){0,16}", ErrorMessage = "This is no IBAN")]
        public string PartnerIBAN { get; set; }
        [DisplayName("Partnername")]
        public string PartnerName { get; set; }


        public IEnumerable<SelectListItem> ContractKinds { get; set; }
        public IEnumerable<SelectListItem> ContractTypes { get; set; }
        public IEnumerable<SelectListItem> ContractSubTypes { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        //Christoph: Chooses the options for the Frame contracts
        [DisplayName("Rahmenvertragsoptionen")]
        public string FrameOptionChosen { get; set; }
        [DisplayName("Rahmenvertrag auswählen")]
        public int? MainFrameIdSelected { get; set; }
        public IEnumerable<SelectListItem> FrameContractChoice { get; set; }
        public IEnumerable<SelectListItem> MainFrameContracts { get; set; }

        //public virtual ContractPartner ContractPartner { get; set; }

        public WebApplication1.Models.Contract Contract { get; set; }
    }


}