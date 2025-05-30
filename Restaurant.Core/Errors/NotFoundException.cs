using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Errors
{
    public class NotFoundException(string message)
        : ServiceException(StatusCodes.Status404NotFound , message)
    {
    }
}
