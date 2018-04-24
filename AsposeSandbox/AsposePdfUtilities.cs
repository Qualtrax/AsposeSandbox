using System;
using System.IO;
using Aspose.Pdf;

namespace AsposeExample
{
    public static class AsposePdfUtilities
    {
        public static TReturn ThrowException<TReturn>(Exception ex)
            => throw ex;

        public static TReturn HandleAsposeExceptions<TReturn>(Func<TReturn> operate, Func<Exception, TReturn> catchOperate)
        {
            try
            {
                return operate();
            }
            catch (InvalidFileFormatException invalidFileFormat)
            {
                return catchOperate(MapInvalidFileFormatExceptionToCustomException(invalidFileFormat));
            }
            catch (FileNotFoundException fileNotFound)
            {
                return catchOperate(CommonUtilities.MapFileNotFoundExceptionToCustomException(fileNotFound));
            }
            catch (Exception ex)
            {
                return catchOperate(CommonUtilities.MapExceptionToCustomException(ex));
            }
        }

        public static CustomException MapInvalidFileFormatExceptionToCustomException(InvalidFileFormatException invalidFileFormatException)
            => new CustomException(invalidFileFormatException);

        public static TReturn HandleAsposeExceptionsWithThrow<TReturn>(Func<TReturn> operate)
            => HandleAsposeExceptions(operate, ThrowException<TReturn>);

        public static TReturn HandleAsposeExceptionsWithThrowAndFinally<TReturn>(Func<TReturn> operate, Action finallyOperate)
            => HandleAsposeExceptions(() => CommonUtilities.AndFinally(operate, finallyOperate), ThrowException<TReturn>);
    }
}
