using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Errors
{
    public class ServiceException : Exception
    {
        public int StatusCode {  get; }
        public string ErrorMessage {  get; }
        public ServiceException(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
