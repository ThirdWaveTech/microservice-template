using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __NAME__.Models.Diagnostics
{
    
    public class StatusItem
    {
        public static string OK = "OK";
        public static string Error = "ERROR";
        public StatusItem(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }
}
