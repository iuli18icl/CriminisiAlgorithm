using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriminisiAlgorithm
{
    internal class Utils
    {
        ///////////// RGB /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static byte[,,] ImageToByteArray(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,,] imageArray = new byte[width, height, 3];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    imageArray[i, j, 0] = pixelColor.R;
                    imageArray[i, j, 1] = pixelColor.G;
                    imageArray[i, j, 2] = pixelColor.B;
                }
            }

            return imageArray;
        }

        ///////////// Grayscale /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static byte[,] ConvertImageToGrayscaleArray(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,] grayscaleArray = new byte[width, height];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    byte grayscaleValue = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
                    grayscaleArray[x, y] = grayscaleValue;
                }
            }

            return grayscaleArray;
        }

        // functie pt a transforma din <byte[,]> in <rectangle>
        public static Rectangle BlockToRectangle(IBlock block)
        {
            return new Rectangle(block.X, block.Y, block.Height, block.Width);
        }

        // functii pt overlapping
        public static bool CheckOverlap(Rectangle blockA, Rectangle blockB)
        {
            return blockA.IntersectsWith(blockB);
        }
    }
}
