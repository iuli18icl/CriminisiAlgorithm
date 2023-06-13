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

        public BlockRGB(Point topLeft, Size size)
        {
            TopLeft = topLeft;
            Size = size;

            RedPixels = new byte[size.Height, size.Width];
            GreenPixels = new byte[size.Height, size.Width];
            BluePixels = new byte[size.Height, size.Width];
        }

        public void SetPixels(byte[,] RedPixels, byte[,] GreenPixels, byte[,] BluePixels)
        {
            this.RedPixels = RedPixels;
            this.GreenPixels = GreenPixels;
            this.BluePixels = BluePixels;
        }
    }
}
