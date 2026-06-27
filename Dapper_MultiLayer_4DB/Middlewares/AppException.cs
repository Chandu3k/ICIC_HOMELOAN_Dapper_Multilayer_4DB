using System.Globalization;

namespace ICICBank_HomeLoan.Middlewares
{
    public class AppException: Exception
    {
        public AppException() : base () { }
        public AppException(string message) : base(message) { }
        protected AppException(string message, Exception innerException) : base(message, innerException) { }

    }
}
