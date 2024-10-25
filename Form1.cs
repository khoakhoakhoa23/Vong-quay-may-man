using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
   
    public partial class Form1 : Form
    {
        bool wheelIsMoved;// biến boolean dùng để xác định vòng quay di chuyển hay không
        float wheelTimes;//luu trữ số lần vòng quay sẽ quay     
        Timer wheelTimer;//bộ đếm thời gian
        LuckyCirlce koloFortuny;//đại diện cho vòng quay may mắn chứa thông tin về trạng thái vong quay
        public Form1()
        {
            InitializeComponent(); //khoi tao cac thành phần trên form        
            wheelTimer = new Timer(); 
            wheelTimer.Interval = 30; // thiết lập 1 lần click là 30 giây
            wheelTimer.Tick += wheelTimer_Tick;
            koloFortuny = new LuckyCirlce();// tạo ra 1 đối tượng LuckyCrilce đại diện cho vòng quay
           
        }
        public class LuckyCirlce
        {
            public Bitmap obrazek;//hình anh của vòng quay
            public Bitmap tempObrazek;// hinh anh của vòng quay
            public float kat;// lưu trữ góc quay của vòng quay
            public int[] wartosciStanu;//mảng chứa các giá trị ngẫu nhiên
            public int stan;// lưu trữ trạng thái hiện tại của vòng quay

            public LuckyCirlce()
            {
                tempObrazek = new Bitmap(Properties.Resources.lucky_wheel);
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = new int[] { 20,32,23,1,3,41,54,54,3,53,64,69,56,87,43};
                kat = 0.0f;
            }

        }
 
        public static Bitmap RotateImage(Image image, float angle)// phuong thuc chịu trách nhiệm xoay hinh ảnh theo 1 góc nhất định
        {
            return RotateImage(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);// xoay hình ảnh xung quanh tâm của nó
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)// phuong thuc thực hiện vòng xoay
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

            if (wheelIsMoved && wheelTimes > 0)// nếu vòng quay đang di chuyển và số vòng quay còn lại lớn hơn 0, thì chương trình sẽ tiếp tục quay
            {
                koloFortuny.kat += wheelTimes / 10;// cập nhật góc quay của vòng quay dựa trên wheelTimes
                koloFortuny.kat = koloFortuny.kat % 360;// quay 360 do
                RotateImage(pictureBox1, koloFortuny.obrazek, koloFortuny.kat);// gọi phương thức xuay hình ảnh đẻ cập nahatj hình anh quay vòng
                wheelTimes--;
            }

            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / 30));

            if (koloFortuny.stan == 0)
            {
                koloFortuny.stan = 0;
            }
            else
            {
                koloFortuny.stan -= 1;
            }
       
            label1.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);

           
        }

        private void BtnPlay_Click(object sender, EventArgs e)// dc gọi khi người nhấn nút Play
        {
            wheelIsMoved = true;// bắt đầu cho phép vòng quay di chuyển
            Random rand = new Random();//
            wheelTimes = rand.Next(150, 200);    //tạo ra 1 giá trị ngẫu nhiên cho số lần vòng quay, từ 150 to 200   
         
            wheelTimer.Start();// khoi động bộ đếm thời gian để bắt đầu quay vòng
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Khi nhấn vào pictureBox1, vòng quay sẽ tự động bắt đầu quay
            // wheelIsMoved = true;  // Bắt đầu quay vòng
            //Random rand = new Random();
            //wheelTimes = rand.Next(150, 200); // Random số vòng quay
            //wheelTimer.Start();  // Bắt đầu Timer để quay vòng

            wheelIsMoved = true;  // Bắt đầu quay vòng
            int inputTimes;

            // Kiểm tra xem người dùng có nhập số hợp lệ không
            if (int.TryParse(txtWheelTimes.Text, out inputTimes) && inputTimes > 0)
            {
                wheelTimes = inputTimes; // Sử dụng số vòng quay người dùng nhập vào
            }
            else
            {
                // Nếu không nhập giá trị hợp lệ, sử dụng giá trị ngẫu nhiên
                Random rand = new Random();
                wheelTimes = rand.Next(150, 200); // Random số vòng quay
            }

            wheelTimer.Start();  // Bắt đầu Timer để quay vòng
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập trạng thái mặc định cho vòng quay khi form được tải lên
            label1.Text = "00";  // Hiển thị giá trị mặc định
            wheelIsMoved = false;  // Vòng quay chưa bắt đầu di chuyển
            MessageBox.Show("Chào mừng bạn đến với trò chơi Vòng quay may mắn!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtWheelTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số từ 0 đến 9
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải số, chặn ký tự
            }
        }

        

        
    }
}
