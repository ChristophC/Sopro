using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskTypes TaskType { get; set; }

        //Dates
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] 
        public Nullable<DateTime> DateCreated { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Expiring { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EscalationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> NotificationDate { get; set; }




        public virtual Contract Contract { get; set; }
        public virtual ContractUser User { get; set; }
    }

    public enum TaskTypes
    {
        DispatcherZuweisen = 1,
        VertragVervollstaendigen,
        DokumenteHochladen,
        KostenAktualisieren,
        VertragsKuendigungChecken
    }
}