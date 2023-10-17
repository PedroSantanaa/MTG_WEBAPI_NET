using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTG_WebAPI_NET.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; } 
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}