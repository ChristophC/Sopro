using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CostKind
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as CostKind;
            if(item != null)
            {
                return Id == item.Id;
            }
            return false;
        }

        public static bool operator ==(CostKind a, CostKind b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CostKind a, CostKind b)
        {
            return !a.Equals(b);
        }
    }
}