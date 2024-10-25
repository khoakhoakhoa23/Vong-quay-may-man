using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();// cho phép người dùng của ưng dụng tuân theo chủ thể 
            Application.SetCompatibleTextRenderingDefault(false);//
            Application.Run(new Form1());//khời động vòng lặp xử lí sự kiện chính của ứng dụng
        }
    }
}
