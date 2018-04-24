using System;
using System.IO;
using Aspose.Pdf;

namespace AsposeExample
{
    public static class AsposePdfUtilities
    {
        public static TReturn WithAsposeExceptions<TReturn>(Func<TReturn> operate)
        {
            try
            {
                return operate();
            }
            catch (InvalidFileFormatException invalidFileFormat)
            {
                throw new CustomException(invalidFileFormat);
            }
            catch (FileNotFoundException fileNotFound)
            {
                throw new CustomException(fileNotFound);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public static Document CreatePdfDocument(string fileName)
            => WithAsposeExceptions(() => new Document(fileName));

        public static Document SavePdfDocument(Document document, string newFileName)
            => WithAsposeExceptions(() => { document.Save(newFileName); return document; });
    }
}
