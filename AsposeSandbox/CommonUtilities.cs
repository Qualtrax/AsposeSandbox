using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeExample
{
    class CommonUtilities
    {
        public static TReturn ThrowException<TReturn>(Exception ex)
            => throw ex;

        public static TReturn AndFinally<TReturn>(Func<TReturn> operate, Action finallyOperate)
        {
            try
            {
                return operate();
            }
            finally
            {
                finallyOperate();
            }
        }

        public static CustomException MapFileNotFoundExceptionToCustomException(FileNotFoundException fileNotFoundException)
            => new CustomException(fileNotFoundException);

        public static CustomException MapExceptionToCustomException(Exception exception)
            => new CustomException(exception);
    }
}
