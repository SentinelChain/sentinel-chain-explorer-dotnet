using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumBlazor.Model
{
    public class OracleQueryDto
    {
        public string Amount { get; set; }
        public string EntryPointId { get; set; }
        public string Parameters { get; set; }
    }
    public class OracleQueryResponse
    {
        public string TransactionId { get; set; }
    }
}
