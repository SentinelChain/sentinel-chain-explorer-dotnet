using System.Numerics;

namespace SentinelChain.Explorer.Messages
{
    public class NewBlock
    {
        public NewBlock(BigInteger blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public BigInteger BlockNumber { get; }
    }
}
