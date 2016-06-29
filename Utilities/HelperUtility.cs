using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class HelperUtility
    {
        public static ContractStatus checkContractStatus (Contract contract, MyDbContext db)
        {
            if(contract.ContractStatus != null)
            {
                string currentStatus = contract.ContractStatus.Description;
                if(currentStatus == "deleted" || currentStatus == "closed")
                {
                    return contract.ContractStatus;
                }
                if(currentStatus == "repealed")
                {
                    //Not implemented yet
                    return contract.ContractStatus;
                }
            }

            if (getAbsoluteContractStatus(contract) > 8)
            {

                return db.ContractStatuses.Where(b => b.Description == "active").FirstOrDefault();
            }
            
            return db.ContractStatuses.Where(b => b.Description == "incomplete").FirstOrDefault();
        }

        public static int getAbsoluteContractStatus(Contract contract)
        {
            int counter = 3; //start at 3 because Signer, Owner and Description are required
            if (contract.ExtContractNum != null) { counter++; }
            if (contract.ContractType != null) { counter++; }
            if (contract.ContractKind != null) { counter++; }
            if (contract.Department != null) { counter++; }
            if (contract.SupervisorDepartment != null) { counter++; }
            if (contract.ContractBegin != null) { counter++; }
            return counter;
        }
    }
}