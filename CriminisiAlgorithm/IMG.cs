using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace CriminisiAlgorithm
{
    internal class IMG
    {
        public List<IBlock> Blocks { get; set; }
        public Image Image { get; set; }
        public Size Size { get; set; }
        public int Step { get; set; }
        public int BlockSize { get; set; }
        public int Lambda { get; set; }
        public Ros ROS { get; set; }


        ///////////// RGB /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Fiecare bloc este format din matrici separate pentru fiecare nivel de culoare RGB
        public void DivideRGBImageIntoBlocks(Image image, int BlockSize, int Step)
        {
            byte[,,] imageStructure = Utils.ImageToByteArray(image);

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

        ///////////// Grayscale /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DivideGrayscaleImageIntoBlocks(Image image, int blockSize, int step)
        {
            byte[,] imageStructure = Utils.ConvertImageToGrayscaleArray(image);

            int width = imageStructure.GetLength(1);    // columns
            int height = imageStructure.GetLength(0);   // rows

            List<IBlock> blocks = new List<IBlock>();

            for (int i = 0; i <= height - blockSize; i += step)
            {
                for (int j = 0; j <= width - blockSize; j += step)
                {
                    byte[,] blockPixels = new byte[blockSize, blockSize];

                    for (int y = 0; y < blockSize; y++)
                    {
                        for (int x = 0; x < blockSize; x++)
                        {
                            blockPixels[y, x] = imageStructure[i + y, j + x];
                        }
                    }

                    BlockGrayscale blockStructure = new BlockGrayscale(new Point(j, i), new Size(blockSize, blockSize), blockPixels);

                    blocks.Add(blockStructure);
                }
            }

            Blocks = blocks;
        }

    }
}
