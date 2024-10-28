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
        List<int> inputNumbers;
        List<Label> wheelLabels; // Store the labels for the wheel

        public Form1()
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
            public float kat;
            public int[] wartosciStanu;
            public int stan;

            public LuckyCirlce(int[] numbers)
            {
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = numbers;
                kat = 0.0f;
            }
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            // Gọi phương thức RotateImage với điểm giữa của hình ảnh làm điểm xoay
            return RotateImage(image, new PointF(image.Width / 2, image.Height / 2), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            // Kiểm tra xem hình ảnh có hợp lệ không
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Tạo một Bitmap mới để lưu hình ảnh đã xoay
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // Di chuyển hệ tọa độ đến điểm xoay
                g.TranslateTransform(offset.X, offset.Y);
                // Xoay hình ảnh
                g.RotateTransform(angle);
                // Quay lại hệ tọa độ ban đầu
                g.TranslateTransform(-offset.X, -offset.Y);
                // Vẽ hình ảnh đã xoay lên Bitmap mới
                g.DrawImage(image, new PointF(0, 0));
            }

            return rotatedBmp;
        }

        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            // Kiểm tra xem bánh xe đã được quay và còn thời gian quay không
            if (wheelIsMoved && wheelTimes > 0)
            {
                // Tăng góc quay theo thời gian
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;

                // Cập nhật hình ảnh trong PictureBox
                pictureBox.Image = RotateImage(koloFortuny.obrazek, koloFortuny.kat);

                // Cập nhật vị trí của các nhãn để xoay cùng với bánh xe
                UpdateLabelPositions(koloFortuny.kat, inputNumbers.Count);

                // Giảm số lần quay
                wheelTimes--;
            }

            // Tính chỉ số phần tử mà bánh xe đang chỉ vào
            koloFortuny.stan = (int)Math.Floor((koloFortuny.kat + 200) / (360.0 / inputNumbers.Count)) % inputNumbers.Count;

            // Đảm bảo rằng chỉ số là hợp lệ
            if (koloFortuny.stan >= 0 && koloFortuny.stan < inputNumbers.Count)
            {
                // Cập nhật văn bản hiển thị trạng thái hiện tại
                label1.Text = Convert.ToString(inputNumbers[koloFortuny.stan]);
            }
            else
            {
                // Xử lý trường hợp chỉ số không hợp lệ
                label1.Text = "Không có kết quả";
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
            if (int.TryParse(textBoxNumber.Text, out int index) && index >= 0 && index < inputNumbers.Count)
            {
                inputNumbers.RemoveAt(index);
                textBoxNumber.Clear(); // Clear the input TextBox after removal
                CreateLabels(); // Recreate labels after removal
                UpdateLabelPositions(0, inputNumbers.Count); // Update positions after removal
            }
            else
            {
                MessageBox.Show("Please enter a valid index to delete.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var values = textBoxNumber.Text.Split(',');

            if (values.Length == 2 &&
                int.TryParse(values[0], out int index) &&
                index >= 0 && index < inputNumbers.Count &&
                int.TryParse(values[1], out int newValue))
            {
                inputNumbers[index] = newValue;
                textBoxNumber.Clear(); // Clear the input TextBox after editing
                CreateLabels(); // Recreate labels after editing
                UpdateLabelPositions(0, inputNumbers.Count);
            }
            else
            {
                MessageBox.Show("Please enter a valid index and new value (format: index,value).");
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
    }
}
