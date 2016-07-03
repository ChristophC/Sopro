using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Models.ViewModels
{
    public class ContractAdvancedSearchViewModel
    {
        //view models do not have any keys. They should not even know what a key is. 
        //A key is something specific to your Data Access Layer that is to say to your Domain Models.
        //public int? Id { get; set; }


        //Strings
        [Display(Name = "Search Bar For Description")]
        [Required(ErrorMessage = "Text required")]
        public string Description { get; set; }
        [DisplayName("Search Bar For Remarks")]
        public string Remarks { get; set; }




        //ints
        [DisplayName("IntContractNumFrom")]
        public string IntContractNumFrom { get; set; }
        [DisplayName("IntContractNumTo")]
        public string IntContractNumTo { get; set; }
        [DisplayName("ExtContractNumFrom")]
        public Nullable<int> ExtContractNumFrom { get; set; }
        [DisplayName("ExtContractNumTo")]
        public Nullable<int> ExtContractNumTo { get; set; }
        [DisplayName("PaymentIntervalFrom")]
        public Nullable<int> PaymentIntervalFrom { get; set; }
        [DisplayName("PaymentIntervalTo")]
        public Nullable<int> PaymentIntervalTo { get; set; }
        [DisplayName("MinContractDurationFrom")]
        public Nullable<int> MinContractDurationFrom { get; set; }
        [DisplayName("MinContractDurationTo")]
        public Nullable<int> MinContractDurationTo { get; set; }
        [DisplayName("AutoExtensionFrom")]
        public Nullable<int> AutoExtensionFrom { get; set; }
        [DisplayName("AutoExtensionTo")]
        public Nullable<int> AutoExtensionTo { get; set; }
        [DisplayName("CancellationPeriodFrom")]
        public Nullable<int> CancellationPeriodFrom { get; set; }
        [DisplayName("CancellationPeriodTo")]
        public Nullable<int> CancellationPeriodTo { get; set; }


        //doubles
        [DisplayName("ContractValueFrom")]
        public Nullable<double> ContractValueFrom { get; set; }
        [DisplayName("ContractValueTo")]
        public Nullable<double> ContractValueTo { get; set; }
        [DisplayName("TaxFrom")]
        public Nullable<double> TaxFrom { get; set; }
        [DisplayName("TaxTo")]
        public Nullable<double> TaxTo { get; set; }
        [DisplayName("AnnualValueFrom")]
        public Nullable<double> AnnualValueFrom { get; set; }
        [DisplayName("AnnualValueTo")]
        public Nullable<double> AnnualValueTo { get; set; }





        //DateTimes
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> PaymentBeginFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> PaymentBeginTo { get; set; }

        [DisplayName("VertragsbeginnFrom")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractBeginFrom { get; set; }
        [DisplayName("VertragsbeginnTo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractBeginTo { get; set; }
        [DisplayName("VertragsendeFrom")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractEndFrom { get; set; }
        [DisplayName("VertragsendeTo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> ContractEndTo { get; set; }
        [DisplayName("CancellationAppointmentFrom")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> CancellationAppointmentFrom { get; set; }
        [DisplayName("CancellationAppointmentTo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //Ober:Edit german Date format
        public Nullable<DateTime> CancellationAppointmentTo { get; set; }





        //
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> ContractStatusId { get; set; }
        public Nullable<int> ContractKindId { get; set; }
        public Nullable<int> ContractTypeId { get; set; }
        public Nullable<int> ContractSubTypeId { get; set; }
        public Nullable<int> CostCenterId { get; set; }
        public Nullable<int> CostKindId { get; set; }
        public Nullable<int> ContractPartnerId { get; set; }











        //DropDownLists
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> ContractStatuses { get; set; }
        public IEnumerable<SelectListItem> ContractTypes { get; set; }
        public IEnumerable<SelectListItem> ContractSubTypes { get; set; }
        public IEnumerable<SelectListItem> ContractKinds { get; set; }
        public IEnumerable<SelectListItem> CostCenters { get; set; }
        public IEnumerable<SelectListItem> CostKinds { get; set; }

        //Bools DropDownLists (JA + NEIN)
        [DisplayName("PrePayable")]
        public Nullable<int> PrePayable { get; set; }
        [DisplayName("VarPayable")]
        public Nullable<int> VarPayable { get; set; }
        [DisplayName("Adaptable")]
        public Nullable<int> Adaptable { get; set; }
        [DisplayName("IsFrameContract")]
        public Nullable<int> IsFrameContract { get; set; }


        //where the results stored
        public List<WebApplication1.Models.Contract> Contracts { get; set; }

        //Sample
        public WebApplication1.Models.Contract sample { get; set; }
    }











    public class ContractSearchLogic
    {
        private List<WebApplication1.Models.Contract> Contracts;

        public ContractSearchLogic()
        {
            Contracts = new List<Models.Contract>();

        }
        public string GenerateQuery(ContractAdvancedSearchViewModel AdvancedSearchViewModel)
        {
            string CmdQueryText;
            string CmdQueryTextSub;
            int counter = 0;
            if (AdvancedSearchViewModel != null)
            {
                CmdQueryText = "SELECT * FROM Contracts";
                CmdQueryTextSub = " WHERE ";

                //Description
                if (!string.IsNullOrEmpty(AdvancedSearchViewModel.Description))
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " Description LIKE '%" + AdvancedSearchViewModel.Description + "%' ";//won't use an index, it will do a full table scan every time.
                        counter++;
                    }

                }

                //Remarks
                if (!string.IsNullOrEmpty(AdvancedSearchViewModel.Remarks))
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " Remarks LIKE '%" + AdvancedSearchViewModel.Remarks + "%' ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND Remarks LIKE '%" + AdvancedSearchViewModel.Remarks + "%' ";

                }

                //Department
                if (AdvancedSearchViewModel.DepartmentId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " DepartmentId = " + AdvancedSearchViewModel.DepartmentId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND DepartmentId = " + AdvancedSearchViewModel.DepartmentId + " ";

                }

                //ContractStatus
                if (AdvancedSearchViewModel.ContractStatusId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " ContractStatus_Id = " + AdvancedSearchViewModel.ContractStatusId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND ContractStatus_Id = " + AdvancedSearchViewModel.ContractStatusId + " ";

                }

                //ContractKind
                if (AdvancedSearchViewModel.ContractKindId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " ContractKind_Id = " + AdvancedSearchViewModel.ContractKindId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND ContractKind_Id = " + AdvancedSearchViewModel.ContractKindId + " ";

                }

                //ContractType
                if (AdvancedSearchViewModel.ContractTypeId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " ContractType_Id = " + AdvancedSearchViewModel.ContractTypeId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND ContractType_Id = " + AdvancedSearchViewModel.ContractTypeId + " ";

                }

                //ContractSubType
                if (AdvancedSearchViewModel.ContractSubTypeId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " ContractSubType_Id = " + AdvancedSearchViewModel.ContractSubTypeId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND ContractSubType_Id = " + AdvancedSearchViewModel.ContractSubTypeId + " ";

                }

                //CostCenter
                if (AdvancedSearchViewModel.CostCenterId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " CostCenter_Id = " + AdvancedSearchViewModel.CostCenterId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND CostCenter_Id = " + AdvancedSearchViewModel.CostCenterId + " ";

                }

                //CostKind
                if (AdvancedSearchViewModel.CostKindId.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " CostKind_Id = " + AdvancedSearchViewModel.CostKindId + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND CostKind_Id = " + AdvancedSearchViewModel.CostKindId + " ";

                }

                //Adaptable
                if (AdvancedSearchViewModel.Adaptable.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " Adaptable = " + AdvancedSearchViewModel.Adaptable + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND Adaptable = " + AdvancedSearchViewModel.Adaptable + " ";

                }

                //PrePayable
                if (AdvancedSearchViewModel.PrePayable.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " PrePayable = " + AdvancedSearchViewModel.PrePayable + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND PrePayable = " + AdvancedSearchViewModel.PrePayable + " ";

                }

                //VarPayable
                if (AdvancedSearchViewModel.VarPayable.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " VarPayable = " + AdvancedSearchViewModel.VarPayable + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND VarPayable = " + AdvancedSearchViewModel.VarPayable + " ";

                }

                //IsFrameContract
                if (AdvancedSearchViewModel.IsFrameContract.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " IsFrameContract = " + AdvancedSearchViewModel.IsFrameContract + " ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND IsFrameContract = " + AdvancedSearchViewModel.IsFrameContract + " ";

                }

                //IntContractNum --From
                if (!string.IsNullOrEmpty(AdvancedSearchViewModel.IntContractNumFrom))
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.IntContractNumFrom + "' <= IntContractNum ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.IntContractNumFrom + "' <= IntContractNum ";

                }

                //IntContractNum --To
                if (!string.IsNullOrEmpty(AdvancedSearchViewModel.IntContractNumTo))
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.IntContractNumTo + "'  >= IntContractNum  ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.IntContractNumTo + "'  >= IntContractNum  ";

                }

                //ExtContractNum --From
                if (AdvancedSearchViewModel.ExtContractNumFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ExtContractNumFrom + "' <= ExtContractNum ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ExtContractNumFrom + "' <= ExtContractNum ";

                }

                //ExtContractNum --To
                if (AdvancedSearchViewModel.ExtContractNumTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ExtContractNumTo + "'  >= ExtContractNum  ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ExtContractNumTo + "'  >= ExtContractNum  ";

                }

                //PaymentInterval  --From
                if (AdvancedSearchViewModel.PaymentIntervalFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.PaymentIntervalFrom + "' <= PaymentInterval ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.PaymentIntervalFrom + "' <= PaymentInterval ";

                }

                //PaymentInterval  --To
                if (AdvancedSearchViewModel.PaymentIntervalTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.PaymentIntervalTo + "' >= PaymentInterval ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.PaymentIntervalTo + "' >= PaymentInterval ";

                }

                //MinContractDuration --From
                if (AdvancedSearchViewModel.MinContractDurationFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.MinContractDurationFrom + "' <= MinContractDuration ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.MinContractDurationFrom + "' <= MinContractDuration ";

                }

                //MinContractDuration --To
                if (AdvancedSearchViewModel.MinContractDurationTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.MinContractDurationTo + "' >= MinContractDuration ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.MinContractDurationTo + "' >= MinContractDuration ";

                }

                //AutoExtension --From
                if (AdvancedSearchViewModel.AutoExtensionFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.AutoExtensionFrom + "' <= AutoExtension ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.AutoExtensionFrom + "' <= AutoExtension ";

                }

                //AutoExtension --To
                if (AdvancedSearchViewModel.AutoExtensionTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.AutoExtensionTo + "' >= AutoExtension ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.AutoExtensionTo + "' >= AutoExtension ";

                }

                //CancellationPeriod  --From
                if (AdvancedSearchViewModel.CancellationPeriodFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.CancellationPeriodFrom + "' <= CancellationPeriod ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.CancellationPeriodFrom + "' <= CancellationPeriod ";

                }

                //CancellationPeriod  --To
                if (AdvancedSearchViewModel.CancellationPeriodTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.CancellationPeriodTo + "' >= CancellationPeriod ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.CancellationPeriodTo + "' >= CancellationPeriod ";

                }

                //ContractValue  --From
                if (AdvancedSearchViewModel.ContractValueFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractValueFrom + "' <= ContractValue ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractValueFrom + "' <= ContractValue ";

                }

                //ContractValue  --To
                if (AdvancedSearchViewModel.ContractValueTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractValueTo + "' >= ContractValue ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractValueTo + "' >= ContractValue ";

                }

                //Tax --From
                if (AdvancedSearchViewModel.TaxFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.TaxFrom + "' <= Tax ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.TaxFrom + "' <= Tax ";

                }

                //Tax --To
                if (AdvancedSearchViewModel.TaxTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.TaxTo + "' >= Tax ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.TaxTo + "' >= Tax ";

                }

                //AnnualValue --From
                if (AdvancedSearchViewModel.AnnualValueFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.AnnualValueFrom + "' <= AnnualValue ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.AnnualValueFrom + "' <= AnnualValue ";

                }

                //AnnualValue --To
                if (AdvancedSearchViewModel.AnnualValueTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.AnnualValueTo + "' >= AnnualValue ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.AnnualValueTo + "' >= AnnualValue ";

                }

                /*
                 *  it is recommended to use ISO8601 format YYYY-MM-DDThh:mm:ss.nnn[ Z ], as this one will not depend on your server's local culture.
                 *  DateTime >= '2011-04-12T00:00:00.000' AND  DateTime <= '2011-05-25T03:53:04.000'
                 *  theDate.ToString("yyyy-MM-dd HH':'mm':'ss")
                 */
                //PaymentBegin  --From
                if (AdvancedSearchViewModel.PaymentBeginFrom != null)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.PaymentBeginFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= PaymentBegin ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.PaymentBeginFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= PaymentBegin ";

                }

                //PaymentBegin  --To
                if (AdvancedSearchViewModel.PaymentBeginTo != null)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.PaymentBeginTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= PaymentBegin ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.PaymentBeginTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= PaymentBegin ";

                }

                //Vertragsbeginn  --From
                if (AdvancedSearchViewModel.ContractBeginFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractBeginFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= ContractBegin ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractBeginFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= ContractBegin ";

                }

                //Vertragsbeginn  --To
                if (AdvancedSearchViewModel.ContractBeginTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractBeginTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= ContractBegin ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractBeginTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= ContractBegin ";

                }

                //Vertragsende  --From
                if (AdvancedSearchViewModel.ContractEndFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractEndFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= ContractEnd ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractEndFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= ContractEnd ";

                }

                //Vertragsende  --To
                if (AdvancedSearchViewModel.ContractEndTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.ContractEndTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= ContractEnd ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.ContractEndTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= ContractEnd ";

                }

                //CancellationAppointment  --From
                if (AdvancedSearchViewModel.CancellationAppointmentFrom.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.CancellationAppointmentFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= CancellationAppointment ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.CancellationAppointmentFrom.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' <= CancellationAppointment ";

                }

                //CancellationAppointment  --To
                if (AdvancedSearchViewModel.CancellationAppointmentTo.HasValue)
                {
                    if (counter == 0)
                    {
                        CmdQueryTextSub = CmdQueryTextSub + " '" + AdvancedSearchViewModel.CancellationAppointmentTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= CancellationAppointment ";
                        counter++;
                    }
                    else
                        CmdQueryTextSub = CmdQueryTextSub + " AND '" + AdvancedSearchViewModel.CancellationAppointmentTo.Value.ToString("yyyy-MM-dd HH':'mm':'ss") + "' >= CancellationAppointment ";

                }

                if (counter != 0)
                    return CmdQueryText + CmdQueryTextSub + " ;";
                else
                    return CmdQueryText + " ;";
            }

            return "does this really Works ??? ";
        }


        public void GetContracts(string CmdQueryText, ContractAdvancedSearchViewModel AdvancedSearchViewModel)
        {
            Nullable<int> T_Id;
            string U_Id;
            MyDbContext db = new MyDbContext();
            //-- For creating the SqlConnection we’ll use the constructor that takes a (connection)string as input parameter. 
            //--I’ve wrapped the SqlConnection in a using block. This ensures that the connection is actually closed once we’re done with it. 
            //--Make sure you actually open the connection only when needed.
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DefaultConnection.mdf;Initial Catalog=DefaultConnection;Integrated Security=True;MultipleActiveResultSets=True"))
            using (SqlCommand cmd = new SqlCommand(CmdQueryText, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            WebApplication1.Models.Contract Contract = new WebApplication1.Models.Contract();
                            // To avoid unexpected bugs access columns by name.
                            Contract.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            Contract.IntContractNum = reader.IsDBNull(reader.GetOrdinal("IntContractNum")) ? null : reader.GetString(reader.GetOrdinal("IntContractNum"));
                            Contract.ExtContractNum = reader.IsDBNull(reader.GetOrdinal("ExtContractNum")) ? null : reader.GetString(reader.GetOrdinal("ExtContractNum"));
                            Contract.ContractValue = reader.IsDBNull(reader.GetOrdinal("ContractValue")) ? (Nullable<double>)null : reader.GetDouble(reader.GetOrdinal("ContractValue"));
                            Contract.Tax = reader.IsDBNull(reader.GetOrdinal("Tax")) ? (Nullable<double>)null : reader.GetDouble(reader.GetOrdinal("Tax"));
                            Contract.AnnualValue = reader.IsDBNull(reader.GetOrdinal("AnnualValue")) ? (Nullable<double>)null : reader.GetDouble(reader.GetOrdinal("AnnualValue"));
                            Contract.PaymentBegin = reader.IsDBNull(reader.GetOrdinal("PaymentBegin")) ? (Nullable<DateTime>)null : reader.GetDateTime(reader.GetOrdinal("PaymentBegin"));
                            Contract.PaymentInterval = reader.IsDBNull(reader.GetOrdinal("PaymentInterval")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("PaymentInterval"));
                            Contract.ContractBegin = reader.IsDBNull(reader.GetOrdinal("ContractBegin")) ? (Nullable<DateTime>)null : reader.GetDateTime(reader.GetOrdinal("ContractBegin"));
                            Contract.MinContractDuration = reader.IsDBNull(reader.GetOrdinal("MinContractDuration")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("MinContractDuration"));
                            Contract.ContractEnd = reader.IsDBNull(reader.GetOrdinal("ContractEnd")) ? (Nullable<DateTime>)null : reader.GetDateTime(reader.GetOrdinal("ContractEnd"));
                            Contract.Description = reader.GetString(reader.GetOrdinal("Description"));
                            Contract.AutoExtension = reader.IsDBNull(reader.GetOrdinal("AutoExtension")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("AutoExtension"));
                            Contract.Remarks = reader.IsDBNull(reader.GetOrdinal("Remarks")) ? null : reader.GetString(reader.GetOrdinal("Remarks"));
                            //Contract.CancellationPeriod = reader.IsDBNull(reader.GetOrdinal("CancellationPeriod")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("CancellationPeriod"));
                            Contract.PrePayable = reader.IsDBNull(reader.GetOrdinal("PrePayable")) ? (Nullable<bool>) null : reader.GetBoolean(reader.GetOrdinal("PrePayable"));
                            Contract.VarPayable = reader.IsDBNull(reader.GetOrdinal("VarPayable")) ? (Nullable<bool>)null : reader.GetBoolean(reader.GetOrdinal("VarPayable"));
                            Contract.Adaptable = reader.IsDBNull(reader.GetOrdinal("Adaptable")) ? (Nullable<bool>)null : reader.GetBoolean(reader.GetOrdinal("Adaptable"));
                            Contract.IsFrameContract = reader.IsDBNull(reader.GetOrdinal("IsFrameContract")) ? (Nullable<bool>)null : reader.GetBoolean(reader.GetOrdinal("IsFrameContract"));
                            Contract.DepartmentId = reader.IsDBNull(reader.GetOrdinal("DepartmentId")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("DepartmentId"));
                            Contract.SupervisorDepartmentId = reader.IsDBNull(reader.GetOrdinal("SupervisorDepartmentId")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("SupervisorDepartmentId"));

                            //Owner
                            U_Id = reader.IsDBNull(reader.GetOrdinal("OwnerId")) ? null : reader.GetString(reader.GetOrdinal("OwnerId"));
                            Contract.Owner = db.Users.SingleOrDefault(s => s.Id == U_Id);
                            U_Id = null;
                            //Dispatcher
                            U_Id = reader.IsDBNull(reader.GetOrdinal("DispatcherId")) ? null : reader.GetString(reader.GetOrdinal("DispatcherId"));
                            Contract.Dispatcher = db.Users.SingleOrDefault(s => s.Id == U_Id);
                            U_Id = null;
                            //Signer
                            U_Id = reader.IsDBNull(reader.GetOrdinal("SignerId")) ? null : reader.GetString(reader.GetOrdinal("SignerId"));
                            Contract.Signer =db.Users.SingleOrDefault(s => s.Id == U_Id);
                            U_Id = null;


                            //ContractStatus
                            T_Id = (reader.IsDBNull(reader.GetOrdinal("ContractStatus_Id")) ? (Nullable<int>) null : reader.GetInt32(reader.GetOrdinal("ContractStatus_Id"))) ; 
                            Contract.ContractStatus = db.ContractStatuses.SingleOrDefault(s => s.Id == T_Id);
                            T_Id = null;

                            //ContractKind
                            T_Id = reader.IsDBNull(reader.GetOrdinal("ContractKind_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("ContractKind_Id"));
                            Contract.ContractKind = db.ContractKinds.SingleOrDefault(s => s.Id == T_Id);
                            T_Id = null;

                            // ContractType
                            T_Id = reader.IsDBNull(reader.GetOrdinal("ContractType_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("ContractType_Id"));
                            Contract.ContractType = db.ContractTypes.SingleOrDefault(s => s.Id == T_Id);
                            T_Id = null;

                            //ContractSubType
                            T_Id = reader.IsDBNull(reader.GetOrdinal("ContractSubType_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("ContractSubType_Id"));
                            ContractSubType Subtype = db.ContractSubTypes.SingleOrDefault(s => s.Id == T_Id);
                            Contract.ContractSubType = Subtype;
                            T_Id = null;

                            //CostCenter
                            //T_Id = reader.IsDBNull(reader.GetOrdinal("CostCenter_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("CostCenter_Id"));
                            //Contract.CostCenter = db.CostCenters.SingleOrDefault(s => s.Id == T_Id);
                            //T_Id = null;

                            // CostKind
                            T_Id = reader.IsDBNull(reader.GetOrdinal("CostKind_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("CostKind_Id"));
                            Contract.CostKind = db.CostKinds.SingleOrDefault(s => s.Id == T_Id);
                            T_Id = null;

                            //ContractPartner
                            T_Id = reader.IsDBNull(reader.GetOrdinal("ContractPartner_Id")) ? (Nullable<int>)null : reader.GetInt32(reader.GetOrdinal("ContractPartner_Id"));
                            Contract.ContractPartner = db.ContractPartners.SingleOrDefault(s => s.Id == T_Id);
                            T_Id = null;

                            Contracts.Add(Contract);
                        }
                    }
                }
            }
            AdvancedSearchViewModel.Contracts = Contracts;
        }
    



        }


}
 