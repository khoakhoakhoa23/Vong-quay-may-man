using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class Form1 : Form
    {
        bool wheelIsMoved;
        float wheelTimes;
        Timer wheelTimer;
        LuckyCirlce koloFortuny;
        List<int> inputNumbers;  // List to store the numbers entered by the user
        List<TextBox> wheelTextBoxes;  // List to hold the pre-existing TextBoxes

        public Form1()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // Speed 
            wheelTimer.Tick += wheelTimer_Tick;
            inputNumbers = new List<int>();  // Initialize the list to store numbers

            // Instead of creating new TextBoxes, add existing TextBoxes from the form
            wheelTextBoxes = new List<TextBox>
            {
                textBox1, textBox2, textBox3, textBox4, textBox5,
                textBox6, textBox7, textBox8, textBox9, textBox10 // Add all pre-existing TextBoxes here
            };
        }

        public class LuckyCirlce
        {
            public Bitmap obrazek;
            public float kat;
            public int[] wartosciStanu;
            public int stan;

            public LuckyCirlce(int[] numbers)
            {
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);  // Replace with your image resource
                wartosciStanu = numbers;
                kat = 0.0f;
            }
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                g.TranslateTransform(offset.X, offset.Y);
                g.RotateTransform(angle);
                g.TranslateTransform(-offset.X, -offset.Y);
                g.DrawImage(image, new PointF(0, 0));
            }

            return rotatedBmp;
        }

        private void UpdateLabelPositions(int numSegments, float angleOffset)
        {
            float sectorAngle = 360f / numSegments; // Angle per sector
            PointF center = new PointF(pictureBox.Width / 2, pictureBox.Height / 2); // Center of the wheel
            float radius = pictureBox.Width / 2 - 50;  // Adjust this to fit the textboxes within the wheel

            for (int i = 0; i < numSegments; i++)
            {
                float angle = (i * sectorAngle + angleOffset - 90) * (float)Math.PI / 180;

                float x = center.X + (float)(radius * Math.Cos(angle)) - wheelTextBoxes[i].Width / 2;
                float y = center.Y + (float)(radius * Math.Sin(angle)) - wheelTextBoxes[i].Height / 2;

                wheelTextBoxes[i].Location = new Point((int)x, (int)y);

                if (i < inputNumbers.Count)
                {
                    wheelTextBoxes[i].Text = inputNumbers[i].ToString();
                }
            }
        }

        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;

                pictureBox.Image = RotateImage(koloFortuny.obrazek, koloFortuny.kat);
                UpdateLabelPositions(koloFortuny.wartosciStanu.Length, koloFortuny.kat);

                wheelTimes--;
            }

            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / (360f / koloFortuny.wartosciStanu.Length))) % koloFortuny.wartosciStanu.Length;

            label1.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (inputNumbers.Count == 0)
            {
                MessageBox.Show("Please enter numbers for the wheel.");
                return;
            }

            koloFortuny = new LuckyCirlce(inputNumbers.ToArray());
            UpdateLabelPositions(inputNumbers.Count, 0);

            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200); // random number of spins

            wheelTimer.Start();
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumber.Text, out int number))
            {
                inputNumbers.Add(number);
                textBoxNumber.Clear();  // Clear the input box for the next number
                UpdateLabelPositions(inputNumbers.Count, 0);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
    }
}
