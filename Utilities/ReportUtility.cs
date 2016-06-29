using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Utilities
{
    public class ReportUtility
    {
        public static int AdvanceDays = 100; //Number of days

        public static ReportDepartmentViewModel ReportDataDept(int DepartmentId, MyDbContext db)
        {

            ReportDepartmentViewModel result = new ReportDepartmentViewModel()
            {
                Name = db.Departments.Find(DepartmentId).DepartmentName,
                NrOContracts = (from c in db.Contracts
                                where DepartmentId == c.DepartmentId
                                select c).Count(),
                NrOSupervisingContracts = (from c in db.Contracts
                                        where DepartmentId == c.SupervisorDepartmentId
                                        select c).Count(),
                ContractsSum = departmentSum(DepartmentId, db),
                NrSoonEnding = (from c in db.Contracts
                                where DepartmentId == c.DepartmentId
                                && (c.ContractEnd.HasValue ? (c.ContractEnd - DateTime.Now).Value.Days <= AdvanceDays : false) //Returns false if ContractEnd is null
                                select c).Count()
            };
            return result;
        }

        //Returns the ReportData for all Departments of one Client
        public static IEnumerable<ReportDepartmentViewModel> ReportDataClient(int ClientId, MyDbContext db)
        {
            List<ReportDepartmentViewModel> results = new List<ReportDepartmentViewModel>();
            List<Department> departments = (from d in db.Departments
                                            where ClientId == d.Client.Id
                                            select d).ToList();
            foreach(Department d in departments)
            {
                results.Add(ReportDataDept(d.Id, db));
            }
            return results;
        }

        private static double departmentSum(int DepartmentId, MyDbContext db)
        {
            double sum = (from c in db.Contracts
                          where c.DepartmentId == DepartmentId
                          && c.AnnualValue.HasValue
                          && !(c.VarPayable.HasValue ? c.VarPayable.Value : false)
                          && !(c.Adaptable.HasValue ? c.VarPayable.Value : false)
                          select c.AnnualValue.Value).Sum();
            var varContracts = from c in db.Contracts
                               where c.DepartmentId == DepartmentId
                               && c.VarPayable.HasValue ? c.VarPayable.Value : false
                               select c;
            foreach (Contract c in varContracts)
            {
                foreach (VarPayment vp in c.VarPayments)
                {
                    sum += vp.VarPaymentValue;
                }
            }
            return sum;
        }

    }
}