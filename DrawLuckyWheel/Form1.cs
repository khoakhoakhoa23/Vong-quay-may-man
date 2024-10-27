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
        List<TextBox> wheelTextBoxes;

        public Form1()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // Tốc độ quay
            wheelTimer.Tick += wheelTimer_Tick;
            inputNumbers = new List<int>();

            wheelTextBoxes = new List<TextBox>
            {
                textBox1, textBox2, textBox3, textBox4, textBox5,
                textBox6, textBox7, textBox8, textBox9, textBox10
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
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = numbers;
                kat = 0.0f;
            }
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF(image.Width / 2, image.Height / 2), angle);
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

        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;

                pictureBox.Image = RotateImage(koloFortuny.obrazek, koloFortuny.kat);

                // Cập nhật vị trí của các TextBox để quay cùng vòng quay
                UpdateTextBoxPositions(koloFortuny.kat, inputNumbers.Count);

                wheelTimes--;
            }

            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / (360f / koloFortuny.wartosciStanu.Length))) % koloFortuny.wartosciStanu.Length;

            label1.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (inputNumbers.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập các số để quay.");
                return;
            }

            koloFortuny = new LuckyCirlce(inputNumbers.ToArray());

            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200); // số vòng quay ngẫu nhiên

            wheelTimer.Start();
        }

        // Thêm một giá trị vào danh sách inputNumbers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumber.Text, out int number))
            {
                inputNumbers.Add(number);
                textBoxNumber.Clear();
                UpdateTextBoxPositions(0, inputNumbers.Count); // Cập nhật vị trí ban đầu
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ.");
            }
        }

        // Xóa giá trị tại một chỉ số từ danh sách inputNumbers
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumber.Text, out int index) && index >= 0 && index < inputNumbers.Count)
            {
                inputNumbers.RemoveAt(index);
                textBoxNumber.Clear();
                UpdateTextBoxPositions(0, inputNumbers.Count); // Cập nhật vị trí sau khi xóa
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một chỉ số hợp lệ để xóa.");
            }
        }

        // Chỉnh sửa giá trị ở một vị trí xác định trong danh sách inputNumbers
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var values = textBoxNumber.Text.Split(',');

            if (values.Length == 2 &&
                int.TryParse(values[0], out int index) &&
                index >= 0 && index < inputNumbers.Count &&
                int.TryParse(values[1], out int newValue))
            {
                inputNumbers[index] = newValue;
                textBoxNumber.Clear();
                UpdateTextBoxPositions(0, inputNumbers.Count);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập chỉ số và giá trị mới hợp lệ (định dạng: chỉ số,giá trị).");
            }
        }

        // Hàm cập nhật vị trí của các TextBox để quay cùng với vòng quay
        private void UpdateTextBoxPositions(double currentAngle, int numSegments)
        {
            double anglePerSegment = 360f / numSegments;
            double radius = pictureBox.Width / 2 - 250; // Adjust the radius as needed
            PointF center = new PointF(pictureBox.Width / 2 - 100, pictureBox.Height / 2 - 50);

            for (int i = 0; i < numSegments; i++)
            {
                double angle = currentAngle + (i * anglePerSegment) - 90; // Start from the top
                double x = center.X + radius * (double)Math.Cos(angle * Math.PI / 180);
                double y = center.Y + radius * (double)Math.Sin(angle * Math.PI / 180);

                wheelTextBoxes[i].Location = new Point((int)x, (int)y);
                wheelTextBoxes[i].Visible = true; // Ensure the textboxes are visible

                // Cập nhật nội dung của TextBox
                if (i < inputNumbers.Count)
                {
                    wheelTextBoxes[i].Text = inputNumbers[i].ToString();
                }
            }
        }
    }
}
