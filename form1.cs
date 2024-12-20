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
        bool wheelIsMoved;//check if the wheel is curenttlyspin    
        float wheelTimes;//represent  how long or how many step the wheel will rotate     
        Timer wheelTimer;//trigger an event at regular intervals
        LuckyCirlce koloFortuny;
        public Form1()
        {
            InitializeComponent();         
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // speed, the timer is set to tick 30 miliseconds
            wheelTimer.Tick += wheelTimer_Tick;// wheelTimer.tick (trigger) wheelTimer_Tick
            koloFortuny = new LuckyCirlce();// manage img and state
           
        }
        public class LuckyCirlce
        {
            public Bitmap obrazek;//represent the img of wheel
            public Bitmap tempObrazek;//temporary copy of the wheel img
            public float kat;// the current angle of rolation for the wheel
            public int[] wartosciStanu;// array represent (values, prize) of the wheel
            public int stan;//the current state of the wheel

            public LuckyCirlce()
            {
                tempObrazek = new Bitmap(Properties.Resources.lucky_wheel);
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = new int[] { 12, 11, 10 ,09, 08, 07, 06, 05, 04, 03, 02, 01};
                kat = 0.0f;
            }

        }
        private string connectionString = "DataSource=localhost; Initial Catalog =CUOI KY; User ID=DESKTOP-FP9EOJM;Password=''";
        public void Save(int userId, int score) {
         string query = "INSERT INTO TongDiem (TenNguoiChoi, Diem, SoLuot) VALUES (@TenNguoiChoi, @Diem, @SoLuot)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
         SqlCommand command = new SqlCommand(query, connection);
         command.Parameters.AddWithValue("@TenNguoiChoi", userId);
         command.Parameters.AddWithValue("@Scor", score);
         command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
         try
         {
             connection.Open();
             int result = command.ExecuteNonQuery();

             // Kiểm tra xem điểm đã được lưu thành công hay chưa
             if (result > 0)
             {
                 Console.WriteLine("Điểm đã được lưu thành công.");
             }
             else
             {
                 Console.WriteLine("Lỗi khi lưu điểm.");
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine("Lỗi: " + ex.Message);
         }
     }
 }
    }
}