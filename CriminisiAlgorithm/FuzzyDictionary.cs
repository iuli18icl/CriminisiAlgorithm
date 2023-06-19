using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class FuzzyDictionary
    {
        public Dictionary<int, double> fuzzyMembershipComputed;
        public readonly int a = 4;
        public readonly int b = 78;

        public int BlockSize { get; set; }

        public FuzzyDictionary(int blockSize)
        {
            this.BlockSize = blockSize;
        }
    }
}
