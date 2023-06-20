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
        //public readonly int a = 4;
        //public readonly int b = 78;
        public int a { get; set; }
        public int b { get; set; }
        public FuzzyDictionary (int textBox9Value, int textBox10Value)
        {
            int a = textBox9Value;
            int b = textBox10Value;
        }

        public int BlockSize { get; set; }

        public FuzzyDictionary(int blockSize)
        {
            this.BlockSize = blockSize;
        }
    }
}
