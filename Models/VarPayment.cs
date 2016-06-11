using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VarPayment
    {
        public int Id { get; set; }
        public DateTime VarPaymentBegin { get; set; }
        public DateTime VarPaymentEnd { get; set; }
        public double VarPaymentValue{ get; set; }
        public string VarPaymentDescription { get; set; }

        public virtual Contract Contract { get; set; }
    }
}