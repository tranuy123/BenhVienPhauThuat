using BenhVienPT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BenhVienPT
{
    public partial class Bacsi : Form
    {
        //kết nối 
        static String connString = @"Data Source=TRANUY\SQLEXPRESS;Initial Catalog=WebBenhVienPT;User ID=sa;Password=123";
        //khai báo
        SqlConnection sqlconnection = new SqlConnection(connString);
        SqlCommand sqlcommand;
        private TaiKhoan acc;
        private DataTable dataTable;

        //Mở kết nối
        private void Openconn()
        {
            if (sqlconnection == null)
            {
                sqlconnection = new SqlConnection(connString);
            }
            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }
        //Đóng kết nối
        private void Closeconn()
        {
            if (sqlconnection.State == ConnectionState.Open && sqlconnection != null)
            {
                sqlconnection.Close();
            }
        }
        public Bacsi(Models.TaiKhoan acc)
        {
            InitializeComponent();
            this.acc = acc;
        }
        public Bacsi()
        {
            InitializeComponent();
        }

        private void Bacsi_Load(object sender, EventArgs e)
        {
            HienThiDSCaMo("");
            LoadLichLam("");
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT n.id as manhanvien, n.tennv, cm.id as macamo,pm.ID as maphongmo,pm.TenPhongMo,c.id as mathoigian,c.TenTGMo as tenthoigian,c.TGBatDau, l.ngay, DATEADD(hour, -1, c.TGBatDau) AS tg_gui_thong_bao,n.email,n.sdt\r\nFROM nhanvien n\r\nINNER JOIN lichmo l ON l.idnv = n.id\r\nINNER JOIN tgmo c ON c.id= l.camo\r\ninner join camo cm on cm.id = l.idcm\r\n\r\ninner join phongmo pm on pm.id = cm.IDPhongMo\r\nwhere idnv = @idnv";
                sqlcommand.Parameters.AddWithValue("@idnv", NhanVien.GetIdNV(acc.Id).Id);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcommand);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Đặt giá trị của timer
            SetTimer1();
        }
        private int currentIndex = 0;
        private List<Tuple<string, DateTime>> thongBaoList = new List<Tuple<string, DateTime>>();
        private void SetTimer1()
        {
            // Tạo danh sách các thông báo cần hiển thị
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime ngaymo = Convert.ToDateTime(row[8]);
                TimeSpan giomo = (TimeSpan)row[9];
                DateTime thoiDiem = ngaymo.Date + giomo;
                if (thoiDiem > DateTime.Now)
                {
                    thongBaoList.Add(new Tuple<string, DateTime>($"Thông báo: bạn có ca mổ trong phòng {row["TenPhongMo"].ToString()} vào ngày {thoiDiem.ToString("dd/MM/yyyy")} vào lúc {thoiDiem.AddHours(1).ToString("HH:mm")}", thoiDiem));
                    // Tạo mail message
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ludtickets@gmail.com");
                    mail.To.Add(row["Email"].ToString());
                    mail.Subject = $"Thông báo: bạn có ca mổ trong phòng {row["TenPhongMo"].ToString()} vào lúc {thoiDiem.AddHours(1).ToString("dd/MM/yyyy HH:mm")}";
                    mail.Body = $"Xin chào,\n\nBạn có ca mổ sắp tới trong phòng {row["TenPhongMo"].ToString()}.\n\nThời gian: {thoiDiem.AddHours(1).ToString("dd/MM/yyyy HH:mm")}\n\nXin vui lòng đến đúng giờ.\n\nTrân trọng,\nBộ phận phòng mổ.";
                    // Gửi email
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("ludtickets@gmail.com", "ejfrgiunzfflqaxs");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            // Sắp xếp danh sách theo thời gian sớm nhất đến muộn nhất
            thongBaoList.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            // Nếu danh sách không rỗng, thiết lập timer để bắt đầu đếm ngược từ thời điểm sớm nhất
            if (thongBaoList.Count > 0)
            {
                timer1.Interval = (int)(thongBaoList[0].Item2 - DateTime.Now).TotalMilliseconds;
                timer1.Enabled = true;
                timer1.Tick += (sender, e) =>
                {
                    // Nếu còn thông báo nào chưa hiển thị, hiển thị thông báo tiếp theo
                    if (currentIndex < thongBaoList.Count)
                    {
                        SystemSounds.Beep.Play(); // phát âm thanh
                        DataRow row = dataTable.Rows[currentIndex];
                        MessageBox.Show(thongBaoList[currentIndex].Item1);
                        currentIndex++;
                    }
                    // Nếu còn thông báo nào chưa hiển thị, đặt lại thời gian cho timer để hiển thị thông báo tiếp theo
                    if (currentIndex < thongBaoList.Count)
                    {
                        timer1.Interval = (int)(thongBaoList[currentIndex].Item2 - DateTime.Now).TotalMilliseconds;
                    }
                    // Nếu đã hiển thị thông báo cho tất cả các thời điểm trong danh sách, tắt timer
                    else
                    {
                        timer1.Enabled = false;
                    }
                };
            }
        }

        private void LoadLichLam(string day)
        {
            try
            {
                Openconn();
                int idnv = NhanVien.GetIdNV(acc.Id).Id;
                sqlcommand = sqlconnection.CreateCommand();
                if (day == "")
                {

                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT join TGMo as TGM  on LT.IDTGMo = TGM.ID where IDNV = @idnv AND NgayTruc >= GETDATE()";
                }
                else
                {
                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT join TGMo as TGM  on LT.IDTGMo = TGM.ID where IDNV = @idnv AND NgayTruc = '" + day + "'";
                }
                sqlcommand.Parameters.AddWithValue("@idnv", idnv);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                liVlichLV.Items.Clear();
                while (reader.Read())
                {

                    DateTime NgayTruc = reader.GetDateTime(0);
                    string thu = NgayTruc.ToString("dddd", new CultureInfo("vi-VN")); // Lấy tên của ngày trong tuần từ cột NgayTruc
                    string TenTGMo = reader.GetString(1);
                    ListViewItem lvi = new ListViewItem(NgayTruc.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(thu); // Thêm giá trị của cột mới "Ngày trong tuần"
                    lvi.SubItems.Add(TenTGMo);
                    liVlichLV.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            LoadLichLam(selectedDate.Date.ToString());
        }

        private void HienThiDSCaMo(string day)
        {
            try
            {
                Openconn();
                int idnv = NhanVien.GetIdNV(acc.Id).Id;
                sqlcommand = sqlconnection.CreateCommand();
                if (day == "")
                {
                    sqlcommand.CommandText = "select DISTINCT  CM.TenCaMo, LM.Ngay, TGM.TenTGMo , PM.TenPhongMo, BA.MaBenhAn, BN.TenBN from CaMo as CM  join LichMo as LM on CM.ID = LM.IDCM join TGMo as TGM on LM.CaMo = TGM.ID join PhongMo as PM on PM.ID = CM.IDPhongMo join BenhAn as BA on BA.ID = CM.IDBenhAn join BenhNhan as BN on BA.IDBenhNhan = BN.ID where LM.IDNV = @idnv AND LM.Ngay >= CONVERT(varchar, GETDATE(), 111)";
                }
                else {
                    sqlcommand.CommandText = "select DISTINCT  CM.TenCaMo, LM.Ngay, TGM.TenTGMo , PM.TenPhongMo, BA.MaBenhAn, BN.TenBN from CaMo as CM  join LichMo as LM on CM.ID = LM.IDCM join TGMo as TGM on LM.CaMo = TGM.ID join PhongMo as PM on PM.ID = CM.IDPhongMo join BenhAn as BA on BA.ID = CM.IDBenhAn join BenhNhan as BN on BA.IDBenhNhan = BN.ID where LM.IDNV = @idnv and LM.Ngay = '" + day + "'";
                }
               
                sqlcommand.Parameters.AddWithValue("@idnv", idnv);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                liVCaMo.Items.Clear();
                while (reader.Read())
                {
                    string TenCaMo = reader.GetString(0);
                    DateTime Ngay = reader.GetDateTime(1);
                    string TenTGMo = reader.GetString(2);
                    string TenPhongMo = reader.GetString(3);
                    string MaBenhAn = reader.GetString(4);
                    string TenBenhNhan = reader.GetString(5);
                    ListViewItem lvi = new ListViewItem(TenCaMo);
                    lvi.SubItems.Add(Ngay.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(TenTGMo);
                    lvi.SubItems.Add(TenPhongMo);
                    lvi.SubItems.Add(MaBenhAn);
                    lvi.SubItems.Add(TenBenhNhan);
                    liVCaMo.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            HienThiDSCaMo(selectedDate.Date.ToString());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult y = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (y == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!");
                this.Hide();
                FormDangNhap logout = new FormDangNhap();
                logout.ShowDialog();
                this.Close();
            }
        }
    }
}
