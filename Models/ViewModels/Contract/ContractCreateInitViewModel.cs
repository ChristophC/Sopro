using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{

    public class ContractCreateInitViewModel
    {
        //● Id auto
        //● Owner auto
        //● Description TextBox
        //● Coordinator DropdownList
        //● CheckBox “
        //○ Am besten Textsuchfeld, da der Signer aus allen Usern kommen
        //kann.
        public int? ContractId { get; set; }

        [Required]
        [DisplayName("Sachlich Vertantwortlicher")]
        public string OwnerId { get; set; }

        [Required]
        [DisplayName("Unterzeichner")]
        public string SignerName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Vertragsgegenstand")]
        public string Description { get; set; }


        public int? ClientIdOfDepartment { get; set; }
        public int? DepartmentIdOfOwner { get; set; }
        public IEnumerable<SelectListItem> OwnerList { get; set; }
        public IEnumerable<SelectListItem> ClientList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

        //this contract is only for the rightFormPartial
        public Contract Contract { get; set; }
    }

}