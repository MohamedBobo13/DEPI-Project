using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.ResponseHandler
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ServiceResponse()
        {
            Success = true;
        }

    }
    public class ServiceResponsewithstatus<T> : ServiceResponse<T>
    {
        public string Status { get; set; }


    }
}
