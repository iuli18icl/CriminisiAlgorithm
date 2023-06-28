using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class BlockGrayscale : IBlock
    {
        public Point TopLeft { get; set; }
        public Size Size { get; set; }

        public int X => TopLeft.X;
        public int Y => TopLeft.Y;
        public int Width => Size.Width;
        public int Height => Size.Height;

        public byte[,] Pixels { get; set; }

        public BlockGrayscale(Point topLeft, Size size, byte[,] Pixels)
        {
            TopLeft = topLeft;
            Size = size;

            SetPixels(Pixels);
        }

        public void SetPixels(byte[,] Pixels)
        { 
            this.Pixels = Pixels;
        }
    }
}
