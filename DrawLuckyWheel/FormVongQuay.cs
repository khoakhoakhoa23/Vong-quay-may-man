using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class FormVongQuay : Form
    {
        bool wheelIsMoved;
        float wheelTimes;
        Timer wheelTimer;
        LuckyCirlce koloFortuny;
        List<int> inputNumbers;
        List<Label> wheelLabels; // Store the labels for the wheel

        public FormVongQuay()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // Speed of rotation
            wheelTimer.Tick += wheelTimer_Tick;
            inputNumbers = new List<int>();
            wheelLabels = new List<Label>(); // Initialize the list for labels
        }

        public class LuckyCirlce
        {
            public Bitmap obrazek;
            public Bitmap tempObrazek;
            public float kat;
            public int[] wartosciStanu;
            public int stan;

            public LuckyCirlce(int[] numbers)
            {
                tempObrazek = new Bitmap(Properties.Resources.lucky_wheel);
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = numbers;
                kat = 0.0f;
            }
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            // Gọi phương thức RotateImage với điểm giữa của hình ảnh làm điểm xoay
            return RotateImage(image, new PointF((float)image.Width / 2-2,(float)image.Height / 2-7), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            // Kiểm tra xem hình ảnh có hợp lệ không
            if (image == null)
                throw new ArgumentNullException("image");

            // Tạo một Bitmap mới để lưu hình ảnh đã xoay
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics g = Graphics.FromImage(rotatedBmp);
                // Di chuyển hệ tọa độ đến điểm xoay
            g.TranslateTransform(offset.X, offset.Y);
                // Xoay hình ảnh
            g.RotateTransform(angle);
                // Quay lại hệ tọa độ ban đầu
            g.TranslateTransform(-offset.X, -offset.Y);
                // Vẽ hình ảnh đã xoay lên Bitmap mới
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }
        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            // Check if the wheel has moved and if there is remaining time to spin
            if (wheelIsMoved && wheelTimes > 0)
            {
                // Increase the rotation angle based on time
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;

                // Update the image in PictureBox
                RotateImage(pictureBox,koloFortuny.obrazek, koloFortuny.kat);

                // Update the positions of labels to rotate with the wheel
                UpdateLabelPositions(koloFortuny.kat, inputNumbers.Count);

                // Decrease the number of spins remaining
                wheelTimes--;
            }
            if(inputNumbers.Count>0)
            {
                // Determine the index of the label that is at the top (0 degrees)
                koloFortuny.stan = ((int)Math.Round((360 - koloFortuny.kat) / (360 / inputNumbers.Count)) + inputNumbers.Count) % inputNumbers.Count;
                // Ensure the index is valid
                if (koloFortuny.stan == 0)
                {
                    koloFortuny.stan = 0;
                }
                // Update the text displayed in label1 with the value of the label at the top
                label1.Text = inputNumbers[koloFortuny.stan].ToString();
            }
            else
            {
                label1.Text = ""; // Clear the label if there are no numbers
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (inputNumbers.Count == 0)
            {
                MessageBox.Show("Please enter numbers to spin.");
                return;
            }

            koloFortuny = new LuckyCirlce(inputNumbers.ToArray());

            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200); // Random number of spins

            wheelTimer.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumber.Text, out int number)) // Use a TextBox for input
            {
                inputNumbers.Add(number);
                textBoxNumber.Clear(); // Clear the input TextBox after adding
                CreateLabels(); // Create labels based on the current count
                UpdateLabelPositions(0, inputNumbers.Count); // Update initial positions
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Clear the inputNumbers list to remove all entries
            inputNumbers.Clear();

            // Clear the TextBox
            textBoxNumber.Clear();

            // Remove all labels from the form
            foreach (var label in wheelLabels)
            {
                this.Controls.Remove(label);
                label.Dispose(); // Dispose of the label to free resources
            }

            // Clear the wheelLabels list
            wheelLabels.Clear();

            // Reset the rotation angle to 0
            koloFortuny.kat = 0.0f; // Set angle to 0

            // Reset the image in PictureBox to the original image
            koloFortuny.obrazek = new Bitmap(Properties.Resources.lucky_wheel); // Reset to the original image
            pictureBox.Image = koloFortuny.obrazek; // Update the PictureBox with the original image

            // Update label1 to indicate no numbers are present
            label1.Text = "No Numbers"; // Or any default message you prefer
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the new value from the TextBox
            if (int.TryParse(textBoxNumber.Text, out int newValue))
            {
                // Find the index of the number to be edited
                int index = inputNumbers.IndexOf(newValue);

                // Check if the number exists in the list
                if (index != -1)
                {
                    // Prompt the user for the new value
                    string newValueInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the new value for " + newValue, "Edit Number", newValue.ToString());

                    if (int.TryParse(newValueInput, out int updatedValue))
                    {
                        // Update the number at the found index
                        inputNumbers[index] = updatedValue;

                        // Update the corresponding label directly without recreating
                        wheelLabels[index].Text = updatedValue.ToString();

                        textBoxNumber.Clear(); // Clear the input TextBox after editing
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid new value.");
                    }
                }
                else
                {
                    MessageBox.Show("Number not found in the list.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number to edit.");
            }
        }

        // Create and position the labels dynamically based on inputNumbers
        private void CreateLabels()
        {
            // Clear existing labels
            foreach (var label in wheelLabels)
            {
                this.Controls.Remove(label);
                label.Dispose(); // Dispose the old labels
            }
            wheelLabels.Clear(); // Clear the list

            // Create new labels
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                Label label = new Label
                {
                    Text = inputNumbers[i].ToString(),
                    Size = new Size(50, 25), // Adjust size for visibility
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent, // Make background transparent
                    ForeColor = Color.Black, // Ensure text color is visible
                    Font = new Font("Arial", 12, FontStyle.Bold) // Adjust font size and style
                };

                wheelLabels.Add(label);
                this.Controls.Add(label); // Add label to the form
            }
        }

        // Update the position of the labels to rotate with the wheel
        private void UpdateLabelPositions(double currentAngle, int numSegments)
        {
            double anglePerSegment = 360f / numSegments;
            double radius = pictureBox.Width / 2 - 250; // Adjust the radius as needed
            PointF center = new PointF(pictureBox.Width / 2 - 120, pictureBox.Height / 2 - 50);

            for (int i = 0; i < numSegments; i++)
            {
                double angle = currentAngle + (i * 36) - 90; // Start from the top
                double x = center.X + radius * (double)Math.Cos(angle * Math.PI / 180);
                double y = center.Y + radius * (double)Math.Sin(angle * Math.PI / 180);

                // Position the label
                wheelLabels[i].Location = new Point((int)x, (int)y);
                wheelLabels[i].Visible = true; // Ensure the labels are visible
                wheelLabels[i].BringToFront();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
