using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int AccountingArea { get; set; }

        public virtual ICollection<CostCenter> CostCenters { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<CoordinatorClient_Relation> CoordinatorClient_Relations { get; set; }

        public override bool Equals (Object o)
        {
            var item = o as Client;
            if (item != null)
            {
                return item.Id == Id;
            }
            return false;
        }

        public static bool operator ==(Client a, Client b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Client a, Client b)
        {
            return !a.Equals(b);
        }
}