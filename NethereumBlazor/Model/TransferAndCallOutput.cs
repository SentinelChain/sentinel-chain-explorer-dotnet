using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NethereumBlazor.Model
{
    public class TransferAndCallOutput
    {
        public string TransactionHash { get; set; }

        public BigInteger CallId { get; set; }
    }
}
