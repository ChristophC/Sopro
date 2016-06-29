using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ContractCreateFilesViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public IEnumerable<HttpPostedFileBase> FilesUpload { get; set; }
        public List<ContractFile> Files { get; set; }
        public int? FileCount { get; set; }

    }
}