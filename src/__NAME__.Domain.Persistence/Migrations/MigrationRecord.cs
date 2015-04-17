using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __NAME__.Domain.Persistence.Migrations
{
    public class MigrationRecord
    {
        public virtual long Version { get; set; }
        public virtual DateTime? AppliedOn { get; set; }
        public virtual string Description { get; set; }
    }
}
