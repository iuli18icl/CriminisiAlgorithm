using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Windows.Forms.AxHost;


namespace CriminisiAlgorithm
{
    internal class Ros
    {
        public List<IBlock> Blocks { get; set; }
        public Point TopLeft { get; set; }
        public Size Size { get; set; }

        public void LoadBlocks(Image image, int blockSize, Point TopLeft, Size Size, int stepSize)
        {
            byte[,,] imageStructure = Utils.ConvertImageToByteArray(image);

            List <IBlock> blocks = new List<IBlock>();

            int width = imageStructure.GetLength(1);
            int height = imageStructure.GetLength(0);

            Size.Width = Math.Min(Size.Width, width - TopLeft.X);
            Size.Height = Math.Min(Size.Height, height - TopLeft.Y);

            int endX = TopLeft.X + Size.Width;
            int endY = TopLeft.Y + Size.Height;

            for (int i = TopLeft.X; i <= endX - blockSize; i += stepSize)
            {
                for (int j = TopLeft.Y; j <= endY - blockSize; j += stepSize)
                {
                    byte[,] blockR = new byte[blockSize, blockSize];
                    byte[,] blockG = new byte[blockSize, blockSize];
                    byte[,] blockB = new byte[blockSize, blockSize];

                    for (int x = 0; x < blockSize; x++)
                    {
                        for (int y = 0; y < blockSize; y++)
                        {
                            blockR[x, y] = imageStructure[i + x, j + y, 0]; // Red channel
                            blockG[x, y] = imageStructure[i + x, j + y, 1]; // Green channel
                            blockB[x, y] = imageStructure[i + x, j + y, 2]; // Blue channel
                        }
                    }

                    BlockRGB blockStructure = new BlockRGB(new Point(i, j), Size, blockR, blockG, blockB);

                    blocks.Add(blockStructure);
                }
            }

            Blocks = blocks;
        }

    }
}
