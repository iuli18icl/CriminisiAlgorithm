﻿using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Text;

namespace CriminisiAlgorithm
{
    public struct CCStatsOp
    {
        public Rectangle Rectangle;
        public int Area;
    }

    public static class UtilsForConnectivity
    {
        ////ToMatrixString(matrix of any type 'T' , delimiter)
        //public static string ToMatrixString<T>(this T[,] matrix, string delimiter = "\t")
        //{
        //    var s = new StringBuilder();

        //    for (var i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (var j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            s.Append(matrix[i, j]).Append(delimiter);
        //        }

        //        s.AppendLine();
        //    }

        //    return s.ToString();
        //}

        public static Bitmap CopyDataToBitmap(byte[,] data, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height); 

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, data[i, j] == 0 ? Color.Black : Color.White);
                }
            }

            return bmp;
        }
    }

    public class ComponentCalculator
    {
        private readonly Emgu.CV.CvEnum.LineType lineType = Emgu.CV.CvEnum.LineType.EightConnected;

        public int GetMatchingDegree(byte[,] binarizedBlock)
        {
            byte[] depthPixelData = new byte[binarizedBlock.Length]; 
            Buffer.BlockCopy(binarizedBlock, 0, depthPixelData, 0, binarizedBlock.Length);
            Bitmap bitmap = UtilsForConnectivity.CopyDataToBitmap(binarizedBlock, binarizedBlock.GetLength(0), binarizedBlock.GetLength(1)); // CopyDataToBitmap(depthPixelData, binarizedBlock.GetLength(0), binarizedBlock.GetLength(1));
            Image<Gray, byte> depthImage = bitmap.ToImage<Gray, byte>();
            var labels = new Mat();
            var stats = new Mat();
            var centroids = new Mat();
            var nLabels = CvInvoke.ConnectedComponentsWithStats(depthImage, labels, stats, centroids, lineType);
            if (nLabels > 1)
            {
                CCStatsOp[] statsop;
                statsop = new CCStatsOp[nLabels];

                stats.CopyTo(statsop);
                int maximumArea = 0;
                for (int i = 1; i < nLabels; i++)
                {
                    if (statsop[i].Area > maximumArea)
                    {
                        maximumArea = statsop[i].Area;
                    }
                }

                return maximumArea;
            }
            return -1;
        }
    }
}
