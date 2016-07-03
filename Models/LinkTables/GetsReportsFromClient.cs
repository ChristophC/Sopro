using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.LinkTables
{
    public class GetsReportsFromClient
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public  virtual Client Client { get; set; }
        public virtual ContractUser User { get; set; }
    }
}