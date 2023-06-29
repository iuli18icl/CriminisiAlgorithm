using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Size(int Height, int Width) 
        {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
