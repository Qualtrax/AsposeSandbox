using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWGToPDFConversionPageSizeIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            DWGToPDFConverter.ConvertDWGToPDF("blocks_and_tables_-_metric.dwg", "pdf1.pdf");
        }
    }
}
