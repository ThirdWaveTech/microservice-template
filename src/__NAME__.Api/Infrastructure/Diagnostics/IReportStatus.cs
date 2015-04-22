using System.Collections.Generic;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Infrastructure.Diagnostics
{
    public interface IReportStatus
    {
        IList<StatusItem> ReportStatus();
    }
}
