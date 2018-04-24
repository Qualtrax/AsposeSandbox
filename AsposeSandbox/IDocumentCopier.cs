using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeExample
{
    public interface IDocumentCopier
    {
        void CopyDocument(string fileName, string newFileName);
    }
}
