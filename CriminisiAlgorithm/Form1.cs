﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriminisiAlgorithm
{
    public partial class Form1 : Form
    {
        Image image;

        // load image in picture box and store the image
        public void LoadImageFromFile(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                image = Image.FromFile(selectedFile);

                pictureBox.Image = image;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            LoadImageFromFile(pictureBox1);
        }

        private void Compute_Click(object sender, EventArgs e)
        {

            if (isRGBChecked)
            {
                Console.WriteLine("rgb checked");
                if (image != null)
                {
                    Console.WriteLine("image good");
                    Bitmap bitmap = new Bitmap(image);

                    int width = bitmap.Width;
                    int height = bitmap.Height;

                    //int blockSize = int.Parse(textBox1.Text);
                    //int stepSize = int.Parse(textBox2.Text);
                    //int startX = int.Parse(textBox3.Text);
                    //int startY = int.Parse(textBox4.Text);
                    //int rosWidth = int.Parse(textBox5.Text);
                    //int rosHeight = int.Parse(textBox6.Text);
                    //int limit = int.Parse(textBox7.Text);

                    int blockSize = 5;
                    int stepSize = 5;
                    int startX = 100;
                    int startY = 200;
                    int rosWidth = width / 2;
                    int rosHeight = height / 2;
                    int lambda = 0;

                    //Rectangle first = new Rectangle(1, 1, 5, 5);
                    //Rectangle second = new Rectangle(4, 7, 3, 3);
                    //bool rez = Utils.CheckOverlap(first, second);
                    //Console.WriteLine(rez);

                    Ros ros = new Ros();
                    ros.LoadBlocks(pictureBox1.Image, blockSize, new Point(startX, startY), new Size(rosWidth, rosHeight), stepSize);
                    List<IBlock> rosBlocks = ros.Blocks;

                    Criminisi criminisi = new Criminisi();
                    criminisi.DivideImageIntoBlocks(pictureBox1.Image, blockSize, stepSize);
                    List<IBlock> imageBlocks = criminisi.Blocks;

                    List<IBlock> diffValues = new List<IBlock>();

                    foreach (BlockRGB rosBlock in rosBlocks)
                    {
                        foreach (BlockRGB imageBlock in imageBlocks)
                        {
                            if (!Utils.CheckOverlap(Utils.BlockToRectangle(rosBlock), Utils.BlockToRectangle(imageBlock)))
                            {
                                byte[,] blockR = new byte[blockSize, blockSize];
                                byte[,] blockG = new byte[blockSize, blockSize];
                                byte[,] blockB = new byte[blockSize, blockSize];

                                for (int i = 0; i < blockSize; i++)
                                {
                                    for (int j = 0; j < blockSize; j++)
                                    {
                                        byte pixelR = (byte)Math.Abs(rosBlock.RedPixels[i, j] - imageBlock.RedPixels[i, j]);
                                        byte pixelG = (byte)Math.Abs(rosBlock.GreenPixels[i, j] - imageBlock.GreenPixels[i, j]);
                                        byte pixelB = (byte)Math.Abs(rosBlock.BluePixels[i, j] - imageBlock.BluePixels[i, j]);

                                        blockR[i, j] = pixelR;
                                        blockG[i, j] = pixelG;
                                        blockB[i, j] = pixelG;

                                        BlockRGB differenceBlock = new BlockRGB(new Point(i, j), new Size(blockSize, blockSize), blockR, blockG, blockB);
                                        diffValues.Add(differenceBlock);
                                    }
                                }
                            }
                        }
                    }

                    //  Verificare
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Print the first block from rosBlocks
                    // Print the first block from rosBlocks
                    BlockRGB firstRosBlock = (BlockRGB)rosBlocks.FirstOrDefault();
                    if (firstRosBlock != null)
                    {
                        Console.WriteLine("First ROS Block:");
                        Console.WriteLine($"Coordinates: {firstRosBlock.TopLeft}");
                        Console.WriteLine($"Size: {firstRosBlock.Size}");
                        Console.WriteLine("Color Components:");
                        Console.WriteLine("Red:");
                        PrintMatrix(firstRosBlock.RedPixels);
                        Console.WriteLine("Green:");
                        PrintMatrix(firstRosBlock.GreenPixels);
                        Console.WriteLine("Blue:");
                        PrintMatrix(firstRosBlock.BluePixels);
                    }

                    // Print the last block from imageBlock
                    BlockRGB lastImageBlock = (BlockRGB)imageBlocks.LastOrDefault();
                    if (lastImageBlock != null)
                    {
                        Console.WriteLine("Last Image Block:");
                        Console.WriteLine($"Coordinates: {lastImageBlock.TopLeft}");
                        Console.WriteLine($"Size: {lastImageBlock.Size}");
                        Console.WriteLine("Color Components:");
                        Console.WriteLine("Red:");
                        PrintMatrix(lastImageBlock.RedPixels);
                        Console.WriteLine("Green:");
                        PrintMatrix(lastImageBlock.GreenPixels);
                        Console.WriteLine("Blue:");
                        PrintMatrix(lastImageBlock.BluePixels);
                    }

                    // Compute the difference between the first block from rosBlocks and the last block from imageBlocks
                    BlockRGB diffBlock = ComputeDifference(firstRosBlock, lastImageBlock);

                    if (diffBlock != null)
                    {
                        Console.WriteLine("Difference Block:");
                        Console.WriteLine($"Coordinates: {diffBlock.TopLeft}");
                        Console.WriteLine($"Size: {diffBlock.Size}");
                        Console.WriteLine("Color Components:");
                        Console.WriteLine("Red:");
                        PrintMatrix(diffBlock.RedPixels);
                        Console.WriteLine("Green:");
                        PrintMatrix(diffBlock.GreenPixels);
                        Console.WriteLine("Blue:");
                        PrintMatrix(diffBlock.BluePixels);
                    }

                    // Helper method to compute the difference between two blocks
                    BlockRGB ComputeDifference(BlockRGB block1, BlockRGB block2)
                    {
                        if (block1 == null || block2 == null)
                            return null;

                        byte[,] diffRedPixels = new byte[blockSize, blockSize];
                        byte[,] diffGreenPixels = new byte[blockSize, blockSize];
                        byte[,] diffBluePixels = new byte[blockSize, blockSize];

                        for (int i = 0; i < blockSize; i++)
                        {
                            for (int j = 0; j < blockSize; j++)
                            {
                                diffRedPixels[i, j] = (byte)Math.Abs(block1.RedPixels[i, j] - block2.RedPixels[i, j]);
                                diffGreenPixels[i, j] = (byte)Math.Abs(block1.GreenPixels[i, j] - block2.GreenPixels[i, j]);
                                diffBluePixels[i, j] = (byte)Math.Abs(block1.BluePixels[i, j] - block2.BluePixels[i, j]);
                            }
                        }

                        return new BlockRGB(block1.TopLeft, block1.Size, diffRedPixels, diffGreenPixels, diffBluePixels);
                    }

                    // Helper method to print a matrix
                    void PrintMatrix(byte[,] matrix)
                    {
                        int rows = matrix.GetLength(0);
                        int columns = matrix.GetLength(1);
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                }
            }
        }

        private bool isRGBChecked = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isRGBChecked = checkBox1.Checked;
        }
    }
}
