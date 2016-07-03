using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using FileHelpers;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.Contract;

namespace WebApplication1.Utilities
{
    public class ExportUtility
    {
        public static void ContractExport(IEnumerable<Contract> contracts, TextWriter writer)
        {
            List<ContractExportViewModel> export = new List<ContractExportViewModel>();
            List<Contract> contractList = contracts.ToList();
            foreach (Contract c in contractList)
            {
                export.Add(new ContractExportViewModel(c));
            }
            var engine = new FileHelperEngine<ContractExportViewModel>()
            {
                HeaderText = typeof(ContractExportViewModel).GetCsvHeader()
            };
            engine.WriteFile(@"C:\Users\Christoph\Desktop\test.csv", export);
        }

       
    }
}