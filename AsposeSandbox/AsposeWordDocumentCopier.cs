using Aspose.Words;

namespace AsposeExample
{
    public class AsposeWordDocumentCopier : IDocumentCopier
    {
        public void CopyDocument(string fileName, string newFileName)
            => AsposeWordUtilities.HandleAsposeExceptionsWithThrow(() => CreateAndSaveDocument(fileName, newFileName));

        private Document CreateAndSaveDocument(string fileName, string newFileName)
        {
            var wordDocument1 = new Document(fileName);
            wordDocument1.Save(newFileName);
            return wordDocument1;
        }
    }
}
