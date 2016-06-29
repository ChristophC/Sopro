using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Period
    {
        public int Id { get; set; }
        [Range(0, 31)]
        public Nullable<int> Days { get; set; }
        public Nullable<int> Months { get; set; }

    }
}