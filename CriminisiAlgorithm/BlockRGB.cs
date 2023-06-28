using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class BlockRGB : IBlock
    {
        public Point TopLeft { get; set; }
        public Size Size { get; set; }

        public int X => TopLeft.X;
        public int Y => TopLeft.Y;
        public int Width => Size.Width;
        public int Height => Size.Height;

        public byte[,] RedPixels { get; set; }
        public byte[,] GreenPixels { get; set; }
        public byte[,] BluePixels { get; set; }
        public IBlock Source { get; set; }
        public IBlock TamperedBlock { get; set; }

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

        //BlockRGB ComputeDifference(BlockRGB block1, BlockRGB block2)
        //{
        //    if (block1 == null || block2 == null)
        //        return null;

        //    int blockSize = Size.Width;

        //    byte[,] diffRedPixels = new byte[blockSize, blockSize];
        //    byte[,] diffGreenPixels = new byte[blockSize, blockSize];
        //    byte[,] diffBluePixels = new byte[blockSize, blockSize];

        //    for (int i = 0; i < blockSize; i++)
        //    {
        //        for (int j = 0; j < blockSize; j++)
        //        {
        //            diffRedPixels[i, j] = (byte)Math.Abs(block1.RedPixels[i, j] - block2.RedPixels[i, j]);
        //            diffGreenPixels[i, j] = (byte)Math.Abs(block1.GreenPixels[i, j] - block2.GreenPixels[i, j]);
        //            diffBluePixels[i, j] = (byte)Math.Abs(block1.BluePixels[i, j] - block2.BluePixels[i, j]);
        //        }
        //    }

        //    return new BlockRGB(block1.TopLeft, block1.Size, diffRedPixels, diffGreenPixels, diffBluePixels);
        //}
    }
}
