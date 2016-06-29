using System.Collections.Generic;
using System.IO;
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
            foreach (Contract c in contracts)
            {
                export.Add(new ContractExportViewModel(c));
            }
            var engine = new FileHelperEngine<ContractExportViewModel>()
            {
                HeaderText = typeof(ContractExportViewModel).GetCsvHeader()
            };
            engine.WriteStream(writer, export);
        }
    }
}