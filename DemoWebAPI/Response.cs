using DemoWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI
{
    public class Response
    {
        List<string> errorList;
        public Book book { get; set; }
        public Response()
        {
            errorList = new List<string>();
        }
        public void AddErrors(string message)
        {
            errorList.Add(message);
        }
        public List<string> getErrorList()
        {
            return errorList;
        }
    }
}
