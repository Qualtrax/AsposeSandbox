using System;
using Aspose.Words.Saving;

namespace AsposeExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileName = "test.doc";
            var newFileName = "newTest.doc";

            IDocumentCopier wordDocumentCopier = new AsposeWordDocumentCopier();
            wordDocumentCopier.CopyDocument(fileName, newFileName);

            IDocumentCopier pdfDocumentCopier = new AsposePdfDocumentCopier();
            pdfDocumentCopier.CopyDocument(fileName, newFileName);
        }
    }
}
