using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ReportClientViewModel
    {

        private List<ReportDepartmentViewModel> _ReportFields = new List<ReportDepartmentViewModel>();
        public int Id { get; set; }
        public List<ReportDepartmentViewModel> ReportFields
        {
            get { return _ReportFields; }
        }

        public void AddSummery()
        {
            _ReportFields.RemoveAll(d => d.Id == -1);//Removes all previously constructed summeries
            ReportDepartmentViewModel summ = new ReportDepartmentViewModel()
            {
                Id = -1,
                Name = "GESAMT:",
                NrOContracts = (from d in _ReportFields select d.NrOContracts).Sum(),
                NrOSupervisingContracts = (from d in _ReportFields select d.NrOSupervisingContracts).Sum(),
                NrAdaptable = (from d in _ReportFields select d.NrAdaptable).Sum(),
            };
            _ReportFields.Add(summ);
        }
    }
}