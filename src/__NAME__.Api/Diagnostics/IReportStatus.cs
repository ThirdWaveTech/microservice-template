using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Diagnostics
{
    public interface IReportStatus
    {
        IList<StatusItem> StatusReport { get; } 
    }
}
