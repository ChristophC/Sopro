using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;
using System.ComponentModel;

namespace WebApplication1.Models.ViewModels
{
    [DelimitedRecord(",")]
    public class ReportDepartmentViewModel
    {
        [DisplayName("Abteilung")]
        [FieldOrder(1), FieldTitle("Abteilung")]
        public string Name { get; set; }
        [DisplayName("Anzahl zugeordn. Verträge")]
        [FieldOrder(2), FieldTitle("Anzahl zugeordn. Verträge")]
        public int NrOContracts { get; set; } //Number of contracts linked to this Department
        [DisplayName("Anzahl überw. Verträge")]
        [FieldOrder(3), FieldTitle("Anzahl überw.Verträge")]
        public int NrOSupervisingContracts { get; set; } //Number of Contracts this Department supervises
        [DisplayName("Anzahl anpassbarer Verträge")]
        [FieldOrder(4), FieldTitle("Anzahl anpassb. Verträge")]
        public int NrAdaptable { get; set; }
        [DisplayName("Gesamtbetrag ü.a. Verträge")]
        [FieldOrder(5), FieldTitle("Gesamtbetrag ü.a. Verträge")]
        public double ContractsSum { get; set; } //Sum of the amount of money all contracts in this Department together
        [DisplayName("enden in 100 Tagen")]
        [FieldOrder(6), FieldTitle("Enden in 100Tagen")]
        public int NrSoonEnding { get; set; } //Number of contracts, ending in a specified amount of time (start <90 days)

    }
}