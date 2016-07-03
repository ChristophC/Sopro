using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractPartner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IBAN { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as ContractPartner;

            if (item != null)
            {
                return item.Id == Id && item.IBAN.Equals(IBAN);
            }
            return false;
        }

        public static bool operator== (ContractPartner a, ContractPartner b)
        {
            return a.Equals(b);
        }

        public static bool operator!= (ContractPartner a, ContractPartner b)
        {
            return !a.Equals(b);
        }
    }
}