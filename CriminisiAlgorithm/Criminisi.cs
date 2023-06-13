using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace CriminisiAlgorithm
{
    internal class Criminisi
    {
        public List<IBlock> Blocks { get; set; }
        public Image Image { get; set; }
        public Size Size { get; set; }
        public int Step { get; set; }
        public int BlockSize { get; set; }
        public int Lambda { get; set; }
        public Ros ROS { get; set; }

        public void DivideImageIntoBlocks(Image image, int BlockSize, int Step)
        {
            byte[,,] imageStructure = Utils.ConvertImageToByteArray(image);

            int width = imageStructure.GetLength(1);    //columns
            int height = imageStructure.GetLength(0);   //row

            List<IBlock> blocks = new List<IBlock>();

            for (int i = 0; i <= height - BlockSize; i += Step)
            {
                for (int j = 0; j <= width - BlockSize; j += Step)
                {
                    byte[,] blockR = new byte[BlockSize, BlockSize];
                    byte[,] blockG = new byte[BlockSize, BlockSize];
                    byte[,] blockB = new byte[BlockSize, BlockSize];

                    for (int y = 0; y < BlockSize; y++)
                    {
                        for (int x = 0; x < BlockSize; x++)
                        {
                            blockR[y, x] = imageStructure[i + y, j + x, 0]; // Red channel
                            blockG[y, x] = imageStructure[i + y, j + x, 1]; // Green channel
                            blockB[y, x] = imageStructure[i + y, j + x, 2]; // Blue channel
                        }
                    }

                    BlockRGB blockStructure = new BlockRGB(new Point(i, j), new Size(width, height), blockR, blockG, blockB);


                    blocks.Add(blockStructure);
                }
            }

            Blocks = blocks;
        }
    }
}
