using AMVTravelBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Exceptions
{
    public class AuthException : Exception
    {
        public AuthErrorCode ErrorCode { get; }

        public AuthException(AuthErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
