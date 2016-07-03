using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class QueryUtility
    {
        /*<!--Oberhauser/-->*/
        //Gets the Departments of Dispatcher depend on the Client
        public static IQueryable<ContractUser> GetCoordinatorsFromClient(string client, MyDbContext db)
        {
            var subQuery = from c in db.CoordinatorClient_Relations
                           where c.Client.ClientName.Equals(client)
                           select c;
            var query = from u in db.Users
                        from c in subQuery
                        where (
                            u.Id.Equals(c.CoordinatorID)
                        )
                        select u;
            return query;
        }

      
        //Gets the Departments of Dispatcher depend on the Client
        public static IQueryable<Department> GetDepartmentsFromClient(string client, MyDbContext db)
        {
            var query = from d in db.Departments
                        where d.Client.ClientName.Equals(client)
                        select d;
            return query;
        }

        //Gets the Dispatchers depend on the Department
        public static IQueryable<ContractUser> GetDispatchersFromDepartment(string department, MyDbContext db)
        {
            /*
            var subQuery =  from du in db.DU_Relations
                            where du.Department.DepartmentName.Equals(selection)
                            select du;
            var query = from u in db.Users
                        join du in subQuery on u.Id equals du.UserID
                        select u;
            var data = new SelectList(query, "Id", "UserName").ToList();
            return Json(data);
            */
            var subQuery = from dep in db.Departments
                           where dep.DepartmentName.Equals(department)
                           select dep;
            var query = from u in db.Users
                        from dep in subQuery
                        where (
                            u.Id.Equals(dep.DispatcherId)
                            || u.Id.Equals(dep.ViceDispatcherId)
                        )
                        select u;
            return query;
        }

        

        //Gets the Departments of UserEmail
        public static IQueryable<Department> GetDepartmentsOfUser(string userName, MyDbContext db)
        {
            var subQuery = from du in db.DepartmentUser_Relations
                           where du.User.UserName.Equals(userName)
                           select du;
            var query = from dep in db.Departments
                        join du in subQuery on dep.Id equals du.DepartmentID
                        select dep;
            return query;

        }

        //Gets the Client of Department
        public static IQueryable<Client> GetClientOfDepartment(string department, MyDbContext db)
        {
            var subQuery = from dep in db.Departments
                           where dep.DepartmentName.Equals(department)
                           select dep;
            var query = from c in db.Clients
                        join dep in subQuery on c.Id equals dep.Client.Id
                        select c;
            return query;
        }

        //Gets the Client of Department
        public static IQueryable<ContractUser> GetUsersFromDepartment(string department, MyDbContext db)
        {
            var subQuery = from dep in db.DepartmentUser_Relations
                           where dep.Department.DepartmentName.Equals(department)
                           select dep;
            var query = from u in db.Users
                        from dep in subQuery
                        where (
                            u.Id.Equals(dep.UserID)
                        )
                        select u;
            return query;
        }

        public static IQueryable<ContractSubType> GetContractSubTypesFromContractTypes(string type, MyDbContext db)
        {
            var query = from s in db.ContractSubTypes
                        where s.ContractType.Description.Equals(type)
                        select s;
            return query;
        }

        public static IQueryable<Contract> GetFrameContractsOfUser(string userName, MyDbContext db)
        {
            var subQuery = from c in db.Contracts
                           where c.IsFrameContract == true
                           select c;
            var query = from c in subQuery
                        where c.Owner.UserName.Equals(userName) || c.Signer.UserName.Equals(userName)
                        select c;
            return query;
        }

        //Gets the Departments of Dispatcher depend on the Client
        public static IQueryable<CostCenter> GetCostCentersFromClient(string client, MyDbContext db)
        {
            var query = from c in db.CostCenters
                        where c.Client.ClientName.Equals(client)
                        select c;
            return query;
        }
        /*<!--Oberhauser end/-->*/



        /*<!--Caesar------->*/
        //Return all contracts that the user has reading rights for
        public static IQueryable<Contract> GetAllReadAbleContractsOfUser(string userName, MyDbContext db)
        {
            var query = from c in db.Contracts
                        where ReadingAllowed(c, userName, db)
                        select c;
            return query;
        }

        //Checks whether a user has reading permissions for a specific contract
        public static bool ReadingAllowed(Contract contract, string userId, MyDbContext db)
        {
            if (contract.OwnerId == userId || contract.SignerId == userId || contract.DispatcherId == userId)
                return true;
            
            //Checks a list of all DepartmentId (or their Ids with) reading rights
            List<int> accesDepts = new List<int>();
            if (contract.DepartmentId.HasValue)
            {
                accesDepts.Add(contract.DepartmentId.Value);
            }
            if (contract.SupervisorDepartmentId.HasValue)
            {
                accesDepts.Add(contract.SupervisorDepartmentId.Value);
            }
            var readDepts = from rd in db.ReadAccessDepartments
                            where rd.ContractId == contract.Id
                            select (int)rd.DepartmentId;
            foreach (int dpt in readDepts)
            {
                accesDepts.Add(dpt);
            }
            foreach (int dpt in accesDepts)
            {
                var userInDept = from dur in db.DepartmentUser_Relations
                                 where dpt == dur.DepartmentID && dur.UserID == userId
                                 select dur;
                if (userInDept.Any()) //Return true if the IEnummerable is not empty
                    return true;
            }

            var readUsers = from au in db.ReadAccessUsers
                            where au.ContractId == contract.Id && au.UserId == userId
                            select au.UserId;
            if (readUsers.Any()) //return true if the IEnummerable is not empty
            {
                return true;
            }
            return false;
            
        }
    }
}