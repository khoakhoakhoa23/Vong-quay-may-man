using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawLuckyWheel // Khai báo một không gian tên gọi là DrawLuckyWheel, giúp tổ chức mã nguồn.
{
    internal class TaiKhoan // Khai báo một lớp có tên là TaiKhoan với mức truy cập internal, có nghĩa là chỉ có thể truy cập trong cùng một assembly.
    {
        // Các trường riêng tư để lưu trữ thông tin tài khoản
        private string tenTaiKhoan; // Một trường riêng tư để lưu tên tài khoản.
        private string matKhau; // Một trường riêng tư để lưu mật khẩu.

        // Constructor mặc định khởi tạo một thể hiện mới của lớp TaiKhoan.
        public TaiKhoan()
        {
        }

        // Constructor có tham số khởi tạo một thể hiện mới của lớp TaiKhoan với tên tài khoản và mật khẩu cụ thể.
        public TaiKhoan(string tenTaiKhoan, string matKhau)
        {
            this.tenTaiKhoan = tenTaiKhoan; // Gán tên tài khoản được cung cấp cho trường riêng tư.
            this.matKhau = matKhau; // Gán mật khẩu được cung cấp cho trường riêng tư.
        }

        // Thuộc tính công khai để lấy hoặc thiết lập tên tài khoản.
        public string TenTaiKhoan
        {
            get => tenTaiKhoan; // Getter cho trường tên tài khoản.
            set => tenTaiKhoan = value; // Setter cho trường tên tài khoản.
        }

        // Thuộc tính công khai để lấy hoặc thiết lập mật khẩu.
        public string MatKhau
        {
            get => matKhau; // Getter cho trường mật khẩu.
            set => matKhau = value; // Setter cho trường mật khẩu.
        }
    }
}