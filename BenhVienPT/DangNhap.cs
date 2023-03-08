using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using BenhVienPT.Models;

namespace BenhVienPT
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            txtName.ForeColor = Color.LightGray; //set thuộc tính
            txtName.Text = "Tài khoản";
            this.txtName.Leave += new System.EventHandler(this.txtAcc_Leave);
            this.txtName.Enter += new System.EventHandler(this.txtAcc_Enter);

            txtPass.ForeColor = Color.LightGray;
            txtPass.Text = "Mật khẩu";
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Mật khẩu")
            {
                txtPass.Clear();
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Mật khẩu";
                txtPass.ForeColor = Color.LightGray;
            }
        }

        private void txtAcc_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Tài khoản")
            {
                txtName.Clear();
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtAcc_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Tài khoản";
                txtName.ForeColor = Color.LightGray;
            }
        }
     
      

        private void txtPass_TextChanged_1(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            if (txtPass.Text == "Mật khẩu" || txtPass.Text == "")
            {
                txtPass.PasswordChar = '\0';
            }
        }

        private void ckbXemMatKhau_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbXemMatKhau.Checked || txtPass.Text == "Mật khẩu")
            { txtPass.PasswordChar = '\0'; }
            else
            { txtPass.PasswordChar = '*'; }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {          
                DialogResult y = MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (y == DialogResult.Yes)
                {
                    this.Close();
                }
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           
                WebBenhVienPTContext context = new WebBenhVienPTContext();
                string taiKhoan = txtName.Text;
                string matKhau = txtPass.Text;

                var acc = context.TaiKhoan
                    .Include(x => x.IdvaiTroNavigation)
                    .Where(x => x.TaiKhoan1.Equals(taiKhoan) && x.MatKhau.Equals(matKhau)).FirstOrDefault();

                if (acc == null)
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi đăng nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (acc.IdvaiTro == 1)
                    {
                        this.Hide();
                      //  MessageBox.Show("Đăng nhập thành công!");
                        FormQuanLyPT form = new FormQuanLyPT(acc);
                        form.ShowDialog();
                        this.Close();
                    }
                if (acc.IdvaiTro == 2)
                {
                    this.Hide();
                    //  MessageBox.Show("Đăng nhập thành công!");
                    Yta form = new Yta(acc);
                    form.ShowDialog();
                    this.Close();
                }
                if (acc.IdvaiTro == 3)
                {
                    this.Hide();
                    //  MessageBox.Show("Đăng nhập thành công!");
                    FormNVVTYT form = new FormNVVTYT(acc);
                    form.ShowDialog();
                    this.Close();
                }
                if (acc.IdvaiTro == 4)
                {
                    this.Hide();
                    //  MessageBox.Show("Đăng nhập thành công!");
                    Bacsi form = new Bacsi(acc);
                    form.ShowDialog();
                    this.Close();
                }
            }
            
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
    
}
