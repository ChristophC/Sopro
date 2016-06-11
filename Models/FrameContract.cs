using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FrameContract
    {
        public int Id { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Contract MainContract { get; set; }
    }
}