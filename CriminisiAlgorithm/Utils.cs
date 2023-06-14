﻿using System;
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

        public static byte[,,] ConvertImageToByteArray(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,,] imageArray = new byte[height, width, 3];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    imageArray[y, x, 0] = pixelColor.R;
                    imageArray[y, x, 1] = pixelColor.G;
                    imageArray[y, x, 2] = pixelColor.B;
                }
            }

            return imageArray;
        }

        // functie pt a transforma din <byte[,]> in <rectangle>
        public static Rectangle BlockToRectangle(IBlock block)
        {
            return new Rectangle(block.X, block.Y, block.Width, block.Height);
        }

        // functii pt overlapping
        public static bool CheckOverlap(Rectangle blockA, Rectangle blockB)
        {
            return blockA.IntersectsWith(blockB);
        }
    }
}
