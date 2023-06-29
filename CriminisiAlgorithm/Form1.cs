using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    public partial class Form1 : Form
    {
        Image image;
        Image<Bgr, byte> blackImage;
        Image originalMask;

        string filename = @"results.txt";

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

        // Load Original Mask
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                originalMask = Image.FromFile(selectedFile);

                pictureBox3.Image = originalMask;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public Form1()
        {
            InitializeComponent();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rbtRGB.Checked = true;
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
            blackImage = new Image<Bgr, byte>(image.Width, image.Height, new Bgr(0, 0, 0));
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ComponentCalculator calculator = new ComponentCalculator();

            List<IBlock> diffValues = new List<IBlock>();

            int startX = int.Parse(textBoxStartX.Text);
            int startY = int.Parse(textBoxStartY.Text);
            int rosWidth = int.Parse(textBoxStartWidth.Text);
            int rosHeight = int.Parse(textBoxStartHeight.Text);
            int lambda = int.Parse(textBoxLambda.Text);
            float threshold = float.Parse(textBoxThreshold.Text); 

            int blockSize = int.Parse(textBox1.Text);
            int stepSize = int.Parse(textBox2.Text);

            int a = int.Parse(textBox9.Text);
            int b = int.Parse(textBox10.Text);

            var fuzzyDict = FuzzyCompute.ComputeFuzzyMembership(blockSize, a, b);
            isRGBChecked = rbtRGB.Checked;
            isGrayscaleChecked = rbtGrayscale.Checked;
            ///////////// RGB /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (isRGBChecked)
            {
                Console.WriteLine("rgb checked");

                if (image != null)
                {
                    Console.WriteLine("image good");

                    Ros ros = new Ros();
                    ros.LoadRGBBlocks(pictureBox1.Image, blockSize, new Point(startX, startY), new Size(rosWidth, rosHeight), stepSize);
                    List<IBlock> rosBlocks = ros.Blocks;

                    IMG imgBlocks = new IMG();
                    imgBlocks.DivideRGBImageIntoBlocks(pictureBox1.Image, blockSize, stepSize);
                    List<IBlock> imageBlocks = imgBlocks.Blocks;

                    Parallel.ForEach(rosBlocks,  item =>
                    {
                        BlockRGB rosBlock = (BlockRGB)item;
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

                                BlockGrayscale differenceBlock = new BlockGrayscale(new Point(rosBlock.X, rosBlock.Y), new Size(blockSize, blockSize), diffPixels);
                                differenceBlock.TamperedBlock = rosBlock;
                                differenceBlock.Source = imageBlock;

                                var x = calculator.GetMatchingDegree(diffPixels);
                                if (x != -1)
                                {
                                    var fuzzyValue = fuzzyDict.fuzzyMembershipComputed[x];
                                    if (fuzzyValue > maxFuzzy && fuzzyValue >= threshold)
                                    {
                                        differenceBlock.MatchingDegree = x;
                                        maxFuzzy = fuzzyValue;
                                        maxBlock = differenceBlock;
                                    }
                                }
                            }
                        }

                        if (maxBlock != null)
                        {
                            diffValues.Add(maxBlock);
                        }
                    });
                }
            }
            else if (isGrayscaleChecked)
            {
                Console.WriteLine("grayscsale checked");

                if (image != null)
                {
                    Console.WriteLine("image good");

                    Ros ros = new Ros();
                    ros.LoadGrayscaleBlocks(pictureBox1.Image, blockSize, new Point(startX, startY), new Size(rosWidth, rosHeight), stepSize);
                    List<IBlock> rosBlocks = ros.Blocks;

                    IMG imgBlocks = new IMG();
                    imgBlocks.DivideGrayscaleImageIntoBlocks(pictureBox1.Image, blockSize, stepSize);
                    List<IBlock> imageBlocks = imgBlocks.Blocks;

                    Parallel.ForEach(rosBlocks, item =>
                    {
                        BlockGrayscale rosBlock = (BlockGrayscale)item;
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

                                BlockGrayscale differenceBlock = new BlockGrayscale(new Point(rosBlock.X, rosBlock.Y), new Size(blockSize, blockSize), diffPixels);
                                differenceBlock.TamperedBlock = rosBlock;
                                differenceBlock.Source = imageBlock;

                                var x = calculator.GetMatchingDegree(diffPixels);
                                if (x != -1)
                                {
                                    var fuzzyValue = fuzzyDict.fuzzyMembershipComputed[x];
                                    if (fuzzyValue > maxFuzzy && x >= threshold)
                                    {
                                        differenceBlock.MatchingDegree = x;
                                        maxFuzzy = fuzzyValue;
                                        maxBlock = differenceBlock;                                     
                                    }
                                }
                            }

                            if (maxBlock != null)
                            {
                                diffValues.Add(maxBlock);
                            }
                        }
                    });
                }
            }

            Console.WriteLine("+");

            foreach (IBlock diffValue in diffValues)
            {
                // Define the rectangle
                int rectX = diffValue.X;
                int rectY = diffValue.Y;
                int rectWidth = diffValue.Width; 
                int rectHeight = diffValue.Height;

                //Console.WriteLine(String.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}", rectX, rectY, rectWidth, rectHeight));

                // To white color
                Bgr rectangleColor = new Bgr(255, 255, 255);

                for (int i = rectX; i < rectX + rectWidth; i++)
                {
                    for (int j = rectY; j < rectY + rectHeight; j++)
                    {
                        //Console.WriteLine(String.Format("i: {0}, j: {1}, limits i: {2}, limits j: {3}", i, j, rectX + rectWidth, rectY + rectHeight));
                        // Set the pixel color
                        blackImage[i, j] = rectangleColor;
                    }
                }

                pictureBox2.Image = blackImage.ToBitmap();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Refresh();
            }

            int TruePositive = 0;
            int TrueNegative = 0;
            int FalsePositive = 0;
            int FalseNegative = 0;

            Bitmap bitmap1 = new Bitmap(blackImage.ToBitmap());
            Bitmap bitmap2 = new Bitmap(originalMask);

            if (bitmap1.Width == bitmap2.Width && bitmap1.Height == bitmap2.Height)
            {
                for (int i = 0; i < bitmap1.Width; i++)
                {
                    for (int j = 0; j < bitmap1.Height; j++)
                    {
                        Color pixel1 = bitmap1.GetPixel(i, j);
                        Color pixel2 = bitmap2.GetPixel(i, j);

                        // pixel1 == alb(1) si pixel2 == alb(1) -> zona alterata
                        if (pixel1.ToArgb() == Color.White.ToArgb() && pixel2.ToArgb() == Color.White.ToArgb())
                        {
                            TruePositive++;
                        }
                        // pixel1 == negru(0) si pixel2 == negru(0) -> zona nealterata
                        else if (pixel1.ToArgb() == Color.Black.ToArgb() && pixel2.ToArgb() == Color.Black.ToArgb())
                        {
                            TrueNegative++;
                        }
                        // pixel1 == alb(1) si pixel2 == negru(0)
                        else if (pixel1.ToArgb() == Color.White.ToArgb() && pixel2.ToArgb() == Color.Black.ToArgb())
                        {
                            FalsePositive++;
                        }
                        // pixel1 == alb(0) si pixel2 == negru(1)
                        else if (pixel1.ToArgb() == Color.Black.ToArgb() && pixel2.ToArgb() == Color.White.ToArgb())
                        {
                            FalseNegative++;
                        }

                    }
                }

                File.AppendAllText(filename, Environment.NewLine);

                Console.WriteLine("TruePositive = " + TruePositive);
                Console.WriteLine("TrueNegative = " + TrueNegative);
                Console.WriteLine("FalsePositive = " + FalsePositive);
                Console.WriteLine("FalseNegative = " + FalseNegative);

                File.AppendAllText(filename, "TruePositive = " + TruePositive + Environment.NewLine);
                File.AppendAllText(filename, "TrueNegative = " + TrueNegative + Environment.NewLine);
                File.AppendAllText(filename, "FalsePositive = " + FalsePositive + Environment.NewLine);
                File.AppendAllText(filename, "FalseNegative = " + FalseNegative + Environment.NewLine);
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            File.AppendAllText(filename, "Time elapsed: " + elapsedTime + Environment.NewLine);
            File.AppendAllText(filename, "Number of best match matrixes: " + diffValues.Count + Environment.NewLine);
            Console.WriteLine("RunTime " + elapsedTime);
            
            MessageBox.Show($"done {elapsedTime} " + diffValues.Count);

            File.AppendAllText(filename, Environment.NewLine);
        }

        private bool isRGBChecked = false;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isRGBChecked = rbtRGB.Checked;
        }

        private bool isGrayscaleChecked = false;
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            isGrayscaleChecked = rbtGrayscale.Checked;
        }

        private bool isANDChecked = false;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRGB.Checked)
            {
                isANDChecked = rbtAnd.Checked ;
            }
            else
            {
                Console.WriteLine("RGB is not checked");
            }
        }

        private bool isORChecked = false;
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRGB.Checked)
            {
                isORChecked = rbtOr.Checked;
            }
            else
            {
                Console.WriteLine("RGB is not checked");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            
        }

        public void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox10_TextChanged(object sender, EventArgs e)
        {
           // int textBox9Value = int.Parse(textBox9.Text);
           // int textBox10Value = int.Parse(textBox10.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAndOr.Enabled = false;
            rbtAnd.Checked = false;
            rbtOr.Checked = false;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            //
            if (rbtRGB.Checked)
            {
                groupBoxAndOr.Enabled = true;
                rbtAnd.Checked = true;
                rbtOr.Checked = false;
            }
        }
    }
    
}
