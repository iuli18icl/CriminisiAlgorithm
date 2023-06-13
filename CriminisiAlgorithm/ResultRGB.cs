using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class ResultRGB
    {
        // vectori care contin blocurile finale (binarizate)
        public int[] RedValues { get; set; }
        public int[] GreenValues { get; set; }
        public int[] BlueValues { get; set; }
        public Operation Operation { get; set; }

        public void SetPixels(int[] RedValues, int[] GreenValues, int[] BlueValues)
        {
            this.RedValues = RedValues;
            this.GreenValues = GreenValues;
            this.BlueValues = BlueValues;
        }
    }
}
