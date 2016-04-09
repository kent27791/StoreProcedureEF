using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreProcedureEF.Configurations;

namespace StoreProcedureEF.Common
{
    public class SqlRequest
    {
        public SqlName CommandName { get; set; }
        public object CommandParams { get; set; }
    }
}
