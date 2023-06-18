using System;
using System.Collections.Generic;
using System.Drawing;
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
        ///////////// RGB /////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                    int threshold = 0;

                    //Rectangle first = new Rectangle(1, 1, 5, 5);
                    //Rectangle second = new Rectangle(4, 7, 3, 3);
                    //bool rez = Utils.CheckOverlap(first, second);
                    //Console.WriteLine(rez);

                    Ros ros = new Ros();
                    ros.LoadRGBBlocks(pictureBox1.Image, blockSize, new Point(startX, startY), new Size(rosWidth, rosHeight), stepSize);
                    List<IBlock> rosBlocks = ros.Blocks;

                    IMG imgBlocks = new IMG();
                    imgBlocks.DivideRGBImageIntoBlocks(pictureBox1.Image, blockSize, stepSize);
                    List<IBlock> imageBlocks = imgBlocks.Blocks;

                    List<BlockRGB> diffValues = new List<BlockRGB>();
                    var fuzzyDict = FuzzyCompute.ComputeFuzzyMembership();

                    List<byte[,]> finalDiffValues = new List<byte[,]>();

                    foreach (BlockRGB rosBlock in rosBlocks)
                    {
                        double maxFuzzy = int.MinValue;
                        BlockGrayscale maxBlock = null;

                        foreach (BlockRGB imageBlock in imageBlocks)
                        {
                            if (!Utils.CheckOverlap(Utils.BlockToRectangle(rosBlock), Utils.BlockToRectangle(imageBlock)))
                            {
                                byte[,] diffRedPixels = new byte[blockSize, blockSize];
                                byte[,] diffGreenPixels = new byte[blockSize, blockSize];
                                byte[,] diffBluePixels = new byte[blockSize, blockSize];
                                byte[,] diffPixels = new byte[blockSize, blockSize];

                                for (int i = 0; i < blockSize; i++)
                                {
                                    for (int j = 0; j < blockSize; j++)
                                    {
                                        diffRedPixels[i, j] = (byte)Math.Abs(rosBlock.RedPixels[i, j] - imageBlock.RedPixels[i, j]);
                                        diffGreenPixels[i, j] = (byte)Math.Abs(rosBlock.GreenPixels[i, j] - imageBlock.GreenPixels[i, j]);
                                        diffBluePixels[i, j] = (byte)Math.Abs(rosBlock.BluePixels[i, j] - imageBlock.BluePixels[i, j]);

                                        if (diffRedPixels[i, j] <= lambda)
                                            diffRedPixels[i, j] = 1;
                                        else diffRedPixels[i, j] = 0;

                                        if (diffGreenPixels[i, j] <= lambda)
                                            diffGreenPixels[i, j] = 1;
                                        else diffGreenPixels[i, j] = 0;

                                        if (diffBluePixels[i, j] <= lambda)
                                            diffBluePixels[i, j] = 1;
                                        else diffBluePixels[i, j] = 0;

                                        diffPixels[i, j] = (isANDChecked == true)
                                            ? (byte)(diffRedPixels[i, j] & diffGreenPixels[i, j] & diffBluePixels[i, j])
                                            : (byte)(diffRedPixels[i, j] | diffGreenPixels[i, j] | diffBluePixels[i, j]);
                                    }
                                }

                                ComponentCalculator calculator = new ComponentCalculator();

                                BlockGrayscale differenceBlock = new BlockGrayscale(new Point(0, 0), new Size(blockSize, blockSize), diffPixels);
                                var x = calculator.GetMatchingDegree(diffPixels);
                                if (x != -1)
                                {
                                    var fuzzyValue = fuzzyDict.fuzzyMembershipComputed[x];
                                    if (fuzzyValue > maxFuzzy && fuzzyValue >= threshold)
                                    {
                                        maxFuzzy = fuzzyValue;
                                        maxBlock = differenceBlock;
                                    }
                                }
                            }
                        }

                        if (maxBlock != null)
                        {
                            diffValues.Add(rosBlock);
                        }
                    }
                }
            }
            else if (isGrayscaleChecked)
            {
                Console.WriteLine("grayscsale checked");
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
                    int threshold = 0;

                    Ros ros = new Ros();
                    ros.LoadGrayscaleBlocks(pictureBox1.Image, blockSize, new Point(startX, startY), new Size(rosWidth, rosHeight), stepSize);
                    List<IBlock> rosBlocks = ros.Blocks;

                    IMG imgBlocks = new IMG();
                    imgBlocks.DivideGrayscaleImageIntoBlocks(pictureBox1.Image, blockSize, stepSize);
                    List<IBlock> imageBlocks = imgBlocks.Blocks;

                    List<BlockGrayscale> diffValues = new List<BlockGrayscale>();
                    var fuzzyDict = FuzzyCompute.ComputeFuzzyMembership();

                    foreach (BlockGrayscale rosBlock in rosBlocks)
                    {
                        double maxFuzzy = int.MinValue;
                        BlockGrayscale maxBlock = null;


                        foreach (BlockGrayscale imageBlock in imageBlocks)
                        {
                            if (!Utils.CheckOverlap(Utils.BlockToRectangle(rosBlock), Utils.BlockToRectangle(imageBlock)))
                            {
                                byte[,] diffPixels = new byte[blockSize, blockSize];

                                for (int i = 0; i < blockSize; i++)
                                {
                                    for (int j = 0; j < blockSize; j++)
                                    {
                                        diffPixels[i, j] = (byte)Math.Abs(rosBlock.Pixels[i, j] - imageBlock.Pixels[i, j]);

                                        if (diffPixels[i, j] <= lambda)
                                            diffPixels[i, j] = 1;
                                        else
                                            diffPixels[i, j] = 0;
                                    }
                                }

                                ComponentCalculator calculator = new ComponentCalculator();
                                
                                BlockGrayscale differenceBlock = new BlockGrayscale(new Point(0, 0), new Size(blockSize, blockSize), diffPixels);
                                var x = calculator.GetMatchingDegree(diffPixels);
                                if(x != -1)
                                {
                                    var fuzzyValue = fuzzyDict.fuzzyMembershipComputed[x];
                                    if (fuzzyValue > maxFuzzy && fuzzyValue >= threshold)
                                    {
                                        maxFuzzy = fuzzyValue;
                                        maxBlock = differenceBlock;
                                    }
                                }
                            }
                        }

                        if (maxBlock != null)
                        {
                            diffValues.Add(rosBlock);
                        }
                    }

                }
            }
        }



        private bool isRGBChecked = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isRGBChecked = checkBox1.Checked;
        }

        private bool isGrayscaleChecked = false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isGrayscaleChecked = checkBox2.Checked;
        }

        private bool isANDChecked = false;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            isANDChecked = checkBox3.Checked;
        }

        private bool isORChecked = false;
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            isORChecked = checkBox4.Checked;
        }
    }
}
