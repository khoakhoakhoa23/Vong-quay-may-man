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
        List<Label> wheelLabels;  // List to hold the labels for each segment

        public Form1()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // Speed 
            wheelTimer.Tick += wheelTimer_Tick;
            inputNumbers = new List<int>();  // Initialize the list to store numbers
            wheelLabels = new List<Label>();  // Initialize the list to store labels
        }

        public class LuckyCirlce
        {
            public Bitmap obrazek;
            public float kat;
            public int[] wartosciStanu;
            public int stan;

            // Modify constructor to accept numbers
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
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        // Create the labels for each sector and position them inside the wheel's segments
        private void CreateWheelLabels(int[] numbers)
        {
            float sectorAngle = 360f / numbers.Length; // Angle per sector
            PointF center = new PointF(200,200); // Center of the wheel
            float radius = pictureBox1.Width / 2 - 60;  // Adjust based on your wheel size

            // Clear any existing labels
            foreach (var label in wheelLabels)
            {
                this.Controls.Remove(label);
            }
            wheelLabels.Clear();

            for (int i = 0; i < numbers.Length; i++)
            {
                Label label = new Label();
                label.Text = numbers[i].ToString();
                label.AutoSize = true;
                label.BackColor = Color.Transparent;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                label.ForeColor = Color.Black;

                // Add the label to the form and to the list
                this.Controls.Add(label);
                wheelLabels.Add(label);
            }

            // Initially position the labels based on their sector
            UpdateLabelPositions(numbers.Length, 0);
        }

        // Update the positions of the labels as the wheel rotates
        // Update the positions of the labels as the wheel rotates
        private void UpdateLabelPositions(int numSegments, float angleOffset)
        {
            float sectorAngle = 360f / numSegments; // Angle per sector
            PointF center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2); // Center of the wheel
            float radius = pictureBox1.Width / 2 - 100;  // Adjust this to fit the labels within the wheel

            for (int i = 0; i < numSegments; i++)
            {
                // Calculate the angle for each label considering the wheel's current rotation
                float angle = (i * sectorAngle + angleOffset - 90) * (float)Math.PI / 180;

                // Calculate the new position based on the angle and radius from the center
                float x = center.X + (float)(radius * Math.Cos(angle)) - wheelLabels[i].Width / 2;
                float y = center.Y + (float)(radius * Math.Sin(angle)) - wheelLabels[i].Height / 2;

                // Apply the calculated position to the label
                wheelLabels[i].Location = new Point((int)x, (int)y);

                // Optionally rotate the label text to stay upright or match the segment's angle
                wheelLabels[i].Text = inputNumbers[i].ToString();  // Update text if needed
            }
        }

        // Handle the timer tick to rotate both the wheel and the labels
        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;

                // Rotate the wheel image
                pictureBox1.Image = RotateImage(koloFortuny.obrazek, koloFortuny.kat);

                // Update the label positions to rotate with the wheel
                UpdateLabelPositions(koloFortuny.wartosciStanu.Length, koloFortuny.kat);

                wheelTimes--;
            }

            // Adjusted calculation to prevent out-of-range errors
            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / 30)) - 1;

            // Ensure stan is within bounds
            if (koloFortuny.stan < 0)
            {
                koloFortuny.stan = 0;
            }
            else if (koloFortuny.stan >= koloFortuny.wartosciStanu.Length)
            {
                koloFortuny.stan = koloFortuny.wartosciStanu.Length - 1;
            }

            // Update the label text (if you want to show the current selected value)
            label1.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);
        }

        // Start the wheel spinning
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (inputNumbers.Count == 0)
            {
                MessageBox.Show("Please enter numbers for the wheel.");
                return;
            }

            // Initialize the lucky wheel with the entered numbers
            koloFortuny = new LuckyCirlce(inputNumbers.ToArray());

            // Create the labels for the wheel (they will rotate with the wheel)
            CreateWheelLabels(inputNumbers.ToArray());

            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200); // random number of spins

            wheelTimer.Start();
        }

        // Add a number to the wheel
        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumber.Text, out int number))
            {
                inputNumbers.Add(number);
                textBoxNumber.Clear();  // Clear the input box for the next number
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
    }
}
