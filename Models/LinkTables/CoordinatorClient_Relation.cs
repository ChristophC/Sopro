using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{   

    //Koordinatoren
    public class CoordinatorClient_Relation
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public string CoordinatorID { get; set; }

        public virtual Client Client { get; set; }
        public virtual ContractUser Coordinator { get; set; }
    }
}