using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Contract
    {
        public int Id { get; set; }
        //David: Type of IntContractNum changed to String
        [DisplayName("Int. VertragsNr")]
        public string IntContractNum { get; set; }

        
        


        [DisplayName("Ext. VertragNr")]
        public Nullable<int> ExtContractNum { get; set; }
        public Nullable<double> ContractValue { get; set; }
        public Nullable<double> Tax { get; set; }
        public Nullable<double> AnnualValue { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> PaymentBegin { get; set; }
        public Nullable<int> PaymentInterval { get; set; }
        [DisplayName("Vertragsbeginn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractBegin { get; set; }
        public Nullable<int> MinContractDuration { get; set; }
        [DisplayName("Vertragsende")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractEnd { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Vertragsname")]
        public string Description { get; set; }

        public Nullable<int> AutoExtension { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> CancellationAppointment { get; set; }
        //Kündigungsfrist
        public Nullable<int> CancellationPeriod { get; set; }
        public Nullable<bool> PrePayable { get; set; }
        public Nullable<bool> VarPayable { get; set; }
        public Nullable<bool> Adaptable { get; set; }
        public Nullable<bool> IsFrameContract { get; set; }
        [DisplayName("Zugeordnete Abt.")]
        public Nullable<int> DepartmentId { get; set; }
        //Überwachende Abteilung
        [DisplayName("Überwachende Abt.")]
        public Nullable<int> SupervisorDepartmentId { get; set; }
        public string OwnerId { get; set; }
        [DisplayName("Dispatcher")]
        public string DispatcherId { get; set; }
        [DisplayName("Koordinator")]
        public string CoordinatorId { get; set; }
        [DisplayName("Signer")]
        public string SignerId { get; set; }

        //[DisplayName("Vertragsart")]
        //public int? ContractKindId { get; set; }
        //[DisplayName("Vertragstyp")]
        //public int? ContractTypeId { get; set; }
        //[DisplayName("Vertragsstatus")]
        //public int? ContractStatusId { get; set; }


        public virtual ContractUser Owner { get; set; }
        public virtual ContractUser Dispatcher { get; set; }
        public virtual ContractUser Coordinator { get; set; }
        public virtual ContractUser Signer { get; set; }
        public virtual Department Department { get; set; }
        public virtual Department SupervisorDepartment { get; set; }


        
        public virtual ContractStatus ContractStatus { get; set; }
        public virtual ContractKind ContractKind { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual ContractSubType ContractSubType { get; set; }
        public virtual CostCenter CostCenter { get; set; }
        public virtual CostKind CostKind { get; set; }
        public virtual ContractPartner ContractPartner { get; set; }
        public virtual FrameContract FrameContract { get; set; }
        public virtual PhysicalDocAddress PhysicalDocAddress { get; set; }
        public virtual ICollection<ContractFile> ContractFiles { get; set; }
        public virtual ICollection<VarPayment> VarPayments { get; set; }

    }
}