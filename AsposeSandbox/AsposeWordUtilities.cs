using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

namespace AsposeExample
{
    public static class AsposeWordUtilities
    {
        public static TReturn WithAsposeExceptions<TReturn>(Func<TReturn> operate)
        {
            try
            {
                return operate();
            }
            catch (FileCorruptedException fileCorrupted)
            {
                throw new CustomException(fileCorrupted);
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

        public static Document CreateWordDocument(string fileName)
            => WithAsposeExceptions(() => new Document(fileName));

        public static SaveOutputParameters SaveWordDocument(Document document, string newFileName)
            => WithAsposeExceptions(() => document.Save(newFileName));
    }
}
