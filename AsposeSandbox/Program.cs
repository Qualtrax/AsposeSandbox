namespace AsposeExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileName = "test.doc";
            var newFileName = "newTest.doc";

            var wordDocument1 = AsposeWordUtilities.WithAsposeExceptions(() => new Aspose.Words.Document(fileName));
            var wordDocument2 = AsposeWordUtilities.CreateWordDocument(fileName);

            var wordParameters1 = AsposeWordUtilities.WithAsposeExceptions(() => wordDocument1.Save(newFileName));
            var wordParameters2 = AsposeWordUtilities.SaveWordDocument(wordDocument2, newFileName);

            var pdf1 = AsposePdfUtilities.WithAsposeExceptions(() => new Aspose.Pdf.Document(fileName));
            var pdf2 = AsposePdfUtilities.CreatePdfDocument(fileName);

            pdf1 = AsposePdfUtilities.WithAsposeExceptions(() => { pdf1.Save(newFileName); return pdf1; });
            AsposePdfUtilities.SavePdfDocument(pdf2, newFileName);
        }
    }
}
