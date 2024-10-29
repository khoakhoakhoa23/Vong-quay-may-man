using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if ((txtTaiKhoan.Text == "") || (txtMatKhau.Text == ""))
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin ", "Thông Báo");
            }
            else
            {
                if ((txtTaiKhoan.Text == "admin") && (txtMatKhau.Text == "12345"))
                {
                    MessageBox.Show("Chúc Mừng Bạn Đăng Nhập Thành Công!", "Thông Báo");
                    FormVongQuay f = new FormVongQuay();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn Đăng Nhập Không Thành Công", "Thông báo");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
