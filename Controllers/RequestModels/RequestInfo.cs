using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Controllers.RequestModels
{
    public class RequestInfo
    {
        public string usuario { get; set; }
        public bool modo_rollback { get; set; }
    }
}
