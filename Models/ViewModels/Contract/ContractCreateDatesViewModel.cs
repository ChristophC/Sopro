using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateDatesViewModel
    {
        //● Begin DatePicker
        //○ PaymentBeginn DatePicker
        //● End DatePicker
        //● AutoExtension ( checkbox ) SchiebeRegler
        //(Monate)
        //● CancelationAppointment DatePicker
        //● CancelationPeriod SchiebeRegler
        //(Monate)
        
        public int ContractId { get; set; }

        [DisplayName("Vertragsbeginn")] //4.19 Pflicht
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractBegin { get; set; }

        [DisplayName("Vertragslaufzeitoptionen")] //Ober
        public ContractRuntimeTypes RuntimeType { get; set; }
        //Enum does not need Dropdownlist initialization: Runtimetypes

        [DisplayName("Vertragsende")] //4.23
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractEnd { get; set; }
        [DisplayName("Kündigungsfrist")] //4.20
        public Period CancellationPeriod { get; set; }
        [DisplayName("Kündigungstermin")] //4.21
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> CancellationDate { get; set; }
        [DisplayName("Min. Vertragsdauer")] //4.22
        [Range(12, int.MaxValue)]
        public Nullable<int> MinContractDuration { get; set; }
        [DisplayName("stillschweigende Verlängerung")] //4.24
        public Nullable<int> AutoExtension { get; set; }

        //Used to show infos on rightForm
        public Contract Contract;
    }
}