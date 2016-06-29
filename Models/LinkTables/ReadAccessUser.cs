using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models.LinkTables
{
    public class ReadAccessUser
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string UserId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual ContractUser User { get; set; }
    }
}