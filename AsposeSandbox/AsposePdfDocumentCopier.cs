using Aspose.Pdf;

namespace AsposeExample
{
    public class AsposePdfDocumentCopier : IDocumentCopier
    {
        public void CopyDocument(string fileName, string newFileName)
            => AsposePdfUtilities.HandleAsposeExceptionsWithThrow(() => CreateAndSaveDocument(fileName, newFileName));

        private Document CreateAndSaveDocument(string fileName, string newFileName)
        {
            var pdfDocument1 = new Document(fileName);
            pdfDocument1.Save(newFileName);
            return pdfDocument1;
        }
    }
}