using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class BlockRGB : IBlock
    {
        public Point TopLeft { get; set; }
        public Size Size { get; set; }
        public byte[,] RedPixels { get; set; }
        public byte[,] GreenPixels { get; set; }
        public byte[,] BluePixels { get; set; }

        public BlockRGB(Point topLeft, Size size, byte[,] RedPixels, byte[,] GreenPixels, byte[,] BluePixels)
        {
            TopLeft = topLeft;
            Size = size;

            SetPixels(RedPixels, GreenPixels, BluePixels);
        }

        public void SetPixels(byte[,] RedPixels, byte[,] GreenPixels, byte[,] BluePixels)
        {
            this.RedPixels = RedPixels;
            this.GreenPixels = GreenPixels;
            this.BluePixels = BluePixels;
        }
    }
}
