using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

namespace AsposeExample
{
    public static class AsposeWordUtilities
    {
        public static TReturn ThrowException<TReturn>(Exception ex)
            => throw ex;

        public static TReturn HandleAsposeExceptions<TReturn>(Func<TReturn> operate, Func<Exception, TReturn> catchOperate)
        {
            try
            {
                return operate();
            }
            catch (FileCorruptedException fileCorruptedException)
            {
                return catchOperate(MapFileCorruptedExceptionToCustomException(fileCorruptedException));
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                return catchOperate(CommonUtilities.MapFileNotFoundExceptionToCustomException(fileNotFoundException));
            }
            catch (Exception ex)
            {
                return catchOperate(CommonUtilities.MapExceptionToCustomException(ex));
            }
        }

        public static CustomException MapFileCorruptedExceptionToCustomException(FileCorruptedException fileCorruptedException)
            => new CustomException(fileCorruptedException);

        public static TReturn HandleAsposeExceptionsWithThrow<TReturn>(Func<TReturn> operate)
            => HandleAsposeExceptions(operate, ThrowException<TReturn>);

        public static TReturn HandleAsposeExceptionsWithThrowAndFinally<TReturn>(Func<TReturn> operate, Action finallyOperate)
            => HandleAsposeExceptions(() => CommonUtilities.AndFinally(operate, finallyOperate), ThrowException<TReturn>);
    }
}
