using BenhVienPT.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using ClosedXML.Excel;
using System.Diagnostics;
using LicenseContext = OfficeOpenXml.LicenseContext;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BenhVienPT
{
    public partial class FormNVVTYT : Form
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
        public FormNVVTYT()
        {
            InitializeComponent();
        }

        private void FormNVVTYT_Load(object sender, EventArgs e)
        {

            LoadLichLam("");
            HienThiDSP();
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
                    /*/Gửi SMS
                    /var credentials = Credentials.FromApiKeyAndSecret(
                        "82da7a9a",
                        "ikGrPZh5mxTauyPZ"
                        );

                    var VonageClient = new VonageClient(credentials);
                    var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                    {
                        To = "84786126493",
                        From = "Vonage APIs",
                        Text = $"Xin chào,\n\nBạn có ca mổ sắp tới trong phòng {row["TenPhongMo"].ToString()}.\n\nThời gian: {thoiDiem.AddHours(1).ToString("dd/MM/yyyy HH:mm")}\n\nXin vui lòng đến đúng giờ.\n\nTrân trọng,\nBộ phận phòng mổ."
                });*/


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





        public FormNVVTYT(Models.TaiKhoan acc)
        {
            InitializeComponent();
            this.acc = acc;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void HienThiDSP_1()
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT DISTINCT p.id, p.MaPhongMo, p.tenphongmo, " +
    "CASE WHEN ctv.IDPM IS NOT NULL AND ctv.IDTGM IS NOT NULL THEN 'True' ELSE 'False' END AS trangthai, " +
    "p.Loai, pm.idtgmo " +
    "FROM phongmokt pm " +
    "INNER JOIN PhongMo p ON p.ID = pm.IDPhongMo " +
    "LEFT JOIN ( " +
        "SELECT DISTINCT idpm, IDTGM, ngay " +
        "FROM ChiTietPhongMo " +
        "WHERE ngay = '"+formattedDate+"' " +
    ") ctv ON p.id = ctv.IDPM AND pm.idtgmo = ctv.IDTGM " +
    "ORDER BY TenPhongMo, IDTGMo;";


                SqlDataReader reader = sqlcommand.ExecuteReader();
                listP.Items.Clear();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string MaPhongMo = reader.GetString(1);
                    string TenPhongMo = reader.GetString(2);
                    string TrangThai = reader.GetString(3);
                    string Loai = reader.GetString(4);
                    int idtgm = reader.GetInt32(5);
                    ListViewItem lvi = new ListViewItem(ID.ToString());
                    lvi.SubItems.Add(MaPhongMo);

                    lvi.SubItems.Add(TenPhongMo);
                    lvi.SubItems.Add(Loai);

                    if (TrangThai == "False") // nếu TrangThai == false
                    {
                        lvi.SubItems.Add(TrangThai.ToString());
                        lvi.BackColor = Color.LightGray; // thay đổi màu nền của dòng
                    }
                    else
                    {
                        lvi.SubItems.Add(TrangThai.ToString());

                    }

                    lvi.SubItems.Add(idtgm.ToString());

                    listP.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThiDSP()
        {
            WebBenhVienPTContext context = new WebBenhVienPTContext();

            

            int idnv = NhanVien.GetIdNV(acc.Id).Id;
            textBoxidnv.Text = idnv.ToString();
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT DISTINCT p.id, p.MaPhongMo, p.tenphongmo, " +
    "CASE WHEN ctv.IDPM IS NOT NULL AND ctv.IDTGM IS NOT NULL THEN 'True' ELSE 'False' END AS trangthai, " +
    "p.Loai, pm.idtgmo " +
    "FROM phongmokt pm " +
    "INNER JOIN PhongMo p ON p.ID = pm.IDPhongMo " +
    "LEFT JOIN ( " +
        "SELECT DISTINCT idpm, IDTGM, ngay " +
        "FROM ChiTietPhongMo " +
        "WHERE ngay = CAST(GETDATE() AS DATE) " +
    ") ctv ON p.id = ctv.IDPM AND pm.idtgmo = ctv.IDTGM " +
    "ORDER BY TenPhongMo, IDTGMo;";
                SqlDataReader reader = sqlcommand.ExecuteReader();
                listP.Items.Clear();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string MaPhongMo = reader.GetString(1);
                    string TenPhongMo = reader.GetString(2);
                    string TrangThai = reader.GetString(3);
                    string Loai = reader.GetString(4);
                    int idtgm = reader.GetInt32(5);

                    ListViewItem lvi = new ListViewItem(ID.ToString());
                    lvi.SubItems.Add(MaPhongMo);

                    lvi.SubItems.Add(TenPhongMo);
                    lvi.SubItems.Add(Loai);

                    if (TrangThai=="False") // nếu TrangThai == false
                    {
                        lvi.SubItems.Add(TrangThai.ToString());
                        lvi.BackColor = Color.LightGray; // thay đổi màu nền của dòng
                    }
                    else
                    {
                        lvi.SubItems.Add(TrangThai.ToString());

                    }


                    lvi.SubItems.Add(idtgm.ToString());

                    listP.Items.Add(lvi);
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listP_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (listP.SelectedItems.Count > 0)
            {
                string selectedMaPhongMo = listP.SelectedItems[0].Text;
                string loaiP = listP.SelectedItems[0].SubItems[3].Text;
                string matg = listP.SelectedItems[0].SubItems[5].Text;

                textMP.Text = selectedMaPhongMo;
                textBox2.Text = loaiP;
                textMTG.Text = matg; 

              
                
                    groupBox3.Visible = true;
                
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isChecked_Den = checkBoxDen.Checked;
            bool isChecked_Dao = checkBoxDao.Checked;
            bool isChecked_Keo = checkBoxKeo.Checked;
            bool checkgt = checkboxGT.Checked;
            int slk = Convert.ToInt32(SLKeo.Value);
            int sld = Convert.ToInt32(SLD.Value);
            int slden = Convert.ToInt32(SLDao.Value);
            string trangthai = listP.SelectedItems[0].SubItems[4].Text;
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            int idp = Int32.Parse(textMP.Text);
            int idmtg = Int32.Parse(textMTG.Text);
            if (trangthai == "True")
            {
                MessageBox.Show("đã xác nhận");
            }else
            if (isChecked_Den && isChecked_Dao && isChecked_Keo && checkgt)
            {
                try
                {
                    Openconn();
                    sqlcommand = sqlconnection.CreateCommand();

                    sqlcommand.CommandType = CommandType.Text;

                    // Tạo danh sách bộ giá trị
                    List<Tuple<int, int,int>> data = new List<Tuple<int, int,int>>();
                    if (isChecked_Den)
                    {
                        sqlcommand.CommandText = "SELECT ID FROM vattuyte WHERE tenvt like N'%đèn%'";
                        int id_Den = (int)sqlcommand.ExecuteScalar();
                        data.Add(new Tuple<int, int,int>(idp, id_Den,slden));
                    }
                    if (isChecked_Dao)
                    {
                        sqlcommand.CommandText = "SELECT ID FROM vattuyte WHERE tenvt = 'Dao'";
                        int id_Dao = (int)sqlcommand.ExecuteScalar();
                        data.Add(new Tuple<int, int,int>(idp, id_Dao,sld));
                    }
                    if (isChecked_Keo)
                    {
                        sqlcommand.CommandText = "SELECT ID FROM vattuyte WHERE tenvt like N'%kéo%'";
                        int id_Keo = (int)sqlcommand.ExecuteScalar();
                        data.Add(new Tuple<int, int,int>(idp, id_Keo,slk));
                    }
                    //thêm giá trị cho bảng chitietphongmo
                    sqlcommand.CommandText = "INSERT INTO chitietphongmo (IDPM, IDTGM, TrangThai, ngay) VALUES (@idpm, @idtgm, 'False', @ngay)";
                    sqlcommand.Parameters.Add("@ngay", SqlDbType.Date).Value = formattedDate;
                    sqlcommand.Parameters.AddWithValue("@idpm", idp);
                    sqlcommand.Parameters.AddWithValue("@idtgm", idmtg);
                    sqlcommand.ExecuteNonQuery();

                    // Chèn các bộ giá trị vào bảng chitietvattu
                    sqlcommand.Parameters.Clear();
                    sqlcommand.CommandText = "INSERT INTO chitietvattu (idphongmo, idvattuyte, ngay,idnv,sl) VALUES (@idPM, @idVT,@ngay,@idnv,@sl)";
                    sqlcommand.Parameters.Add("@idPM", SqlDbType.Int);
                    sqlcommand.Parameters.Add("@idVT", SqlDbType.Int);
                    sqlcommand.Parameters.Add("@sl", SqlDbType.Int);

                    sqlcommand.Parameters.Add("@ngay", SqlDbType.Date).Value = formattedDate;
                    sqlcommand.Parameters.AddWithValue("@idnv", NhanVien.GetIdNV(acc.Id).Id);


                    foreach (var item in data)
                    {
                        sqlcommand.Parameters["@idPM"].Value = item.Item1;
                        sqlcommand.Parameters["@idVT"].Value = item.Item2;
                        sqlcommand.Parameters["@sl"].Value = item.Item3;

                        sqlcommand.ExecuteNonQuery();


                    }
                   

                    MessageBox.Show("Thêm thành công!");
                    groupBox3.Visible = false;
                    checkBoxDao.Checked = false;
                    checkBoxDen.Checked = false;
                    checkBoxKeo.Checked = false;
                    checkboxGT.Checked = false;
                    HienThiDSP_1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else
            {
                MessageBox.Show("Vui lòng chọn đầy đủ các vật tư cần thêm");
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HienThiDSP();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
           
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT DISTINCT p.id, p.MaPhongMo, p.tenphongmo, " +
    "CASE WHEN ctv.IDPM IS NOT NULL AND ctv.IDTGM IS NOT NULL THEN 'True' ELSE 'False' END AS trangthai, " +
    "p.Loai, pm.idtgmo " +
    "FROM phongmokt pm " +
    "INNER JOIN PhongMo p ON p.ID = pm.IDPhongMo " +
    "LEFT JOIN ( " +
        "SELECT DISTINCT idpm, IDTGM, ngay " +
        "FROM ChiTietPhongMo " +
        "WHERE ngay = '" + formattedDate + "' " +
    ") ctv ON p.id = ctv.IDPM AND pm.idtgmo = ctv.IDTGM " +
    "ORDER BY TenPhongMo, IDTGMo;";


                SqlDataReader reader = sqlcommand.ExecuteReader();
                listP.Items.Clear();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string MaPhongMo = reader.GetString(1);
                    string TenPhongMo = reader.GetString(2);
                    string TrangThai = reader.GetString(3);
                    string Loai = reader.GetString(4);
                    int IDNV = reader.GetInt32(5);
                    ListViewItem lvi = new ListViewItem(ID.ToString());
                    lvi.SubItems.Add(MaPhongMo);

                    lvi.SubItems.Add(TenPhongMo);
                    lvi.SubItems.Add(Loai);

                    if (TrangThai == "False") // nếu TrangThai == false
                    {
                        lvi.SubItems.Add(TrangThai.ToString());
                        lvi.BackColor = Color.LightGray; // thay đổi màu nền của dòng
                    }
                    else
                    {
                        lvi.SubItems.Add(TrangThai.ToString());

                    }


                    lvi.SubItems.Add(IDNV.ToString());

                    listP.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            /*int idnv = NhanVien.GetIdNV(acc.Id).Id;
            
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT top(1) n.id as manhanvien, n.tennv, cm.id as macamo,pm.ID as maphongmo,pm.TenPhongMo,c.id as mathoigian,c.TenTGMo as tenthoigian,c.TGBatDau, l.ngay, DATEADD(hour, -1, c.TGBatDau) AS tg_gui_thong_bao\r\nFROM nhanvien n\r\nINNER JOIN lichmo l ON l.idnv = n.id\r\nINNER JOIN tgmo c ON c.id= l.camo\r\ninner join camo cm on cm.id = l.idcm\r\n\r\ninner join phongmo pm on pm.id = cm.IDPhongMo\r\nwhere idnv = @idnv";
                sqlcommand.Parameters.AddWithValue("@idnv", idnv);

                SqlDataReader reader = sqlcommand.ExecuteReader();
               
                

                while (reader.Read())
                {
                    DateTime ngaymo = reader.GetDateTime(8);
                    DateTime giomo = reader.GetDateTime(9);
                    
                    DateTime ngay = DateTime.ParseExact(ngaymo.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    DateTime thoiDiem = ngay.Date + TimeSpan.Parse(giomo.ToString());
                    string dinhDangThoiGian = "hh:mm:ss tt"; // định dạng giờ 12h (AM/PM)
                    string gio12h = thoiDiem.ToString(dinhDangThoiGian); // chuyển đổi sang định dạng giờ 12h (AM/PM)
                    textBoxthoidiem.Text = ngaymo.ToString();
                    textBoxdatetime.Text = giomo.ToString();
                    if (thoiDiem > DateTime.Now)
                    {
                        timer1.Interval = (int)(thoiDiem - DateTime.Now).TotalMilliseconds;
                        timer1.Enabled = true;
                        timer1.Tick += (sender, e) =>
                        {
                            MessageBox.Show("Hello world!");

                        };
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
           
        


    }

        private void button3_Click(object sender, EventArgs e)
        {
            //// Cấu hình các thuộc tính cho OpenFileDialog
            //openFileDialog1.Title = "Chọn một file";
            //openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            //try
            //{


            //    // Hiển thị OpenFileDialog và kiểm tra xem người dùng đã chọn tệp tin hay chưa
            //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        // Lấy đường dẫn đến tệp tin được chọn
            //        string filePath = openFileDialog1.FileName;
            //        WebBenhVienPTContext context = new WebBenhVienPTContext();
            //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //        using (var package = new ExcelPackage(new FileInfo(filePath)))
            //        {
            //            var worksheet = package.Workbook.Worksheets[1];
            //            var rows = worksheet.Dimension.Rows;
            //            var columns = worksheet.Dimension.Columns;

            //            for (int row = 2; row <= rows; row++) // Skip header row
            //            {
            //                var record = new BenhAn();

            //                for (int column = 1; column <= columns; column++)
            //                {
            //                    var cellValue = worksheet.Cells[row, column].Value;

            //                    switch (column)
            //                    {
            //                        case 1:
            //                            record.MaBenhAn = (string)cellValue;
            //                            break;
            //                        case 2:
            //                            record.IdbenhNhan = (int)cellValue;
            //                            break;
            //                        case 3:
            //                            record.Idnv = (int)cellValue;
            //                            break;
            //                        case 4:
            //                            record.GhiChu = (string)cellValue;
            //                            break;
            //                        case 5:
            //                            record.TrangThai = (Boolean)cellValue;
            //                            break;
            //                        case 6:
            //                            record.Ylenh = (string)cellValue;
            //                            break;
            //                        case 7:
            //                            record.TrangThaiSauMo = (Boolean)cellValue;
            //                            break;

            //                    }
            //                }

            //                // Add the record to your database
            //                context.BenhAn.Add(record);
            //            }

            //            context.SaveChanges();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                // Tạo danh sách tạm thời chứa các mục thỏa mãn điều kiện tìm kiếm
                List<ListViewItem> matchingItems = new List<ListViewItem>();

                foreach (ListViewItem item in listP.Items)
                {
                    if (item.SubItems[0].Text.ToLower().Contains(textBox1.Text.ToLower()) ||
                        item.SubItems[1].Text.ToLower().Contains(textBox1.Text.ToLower()) ||
                        item.SubItems[2].Text.ToLower().Contains(textBox1.Text.ToLower()) ||
                        item.SubItems[3].Text.ToLower().Contains(textBox1.Text.ToLower()) ||
                        item.SubItems[4].Text.ToLower().Contains(textBox1.Text.ToLower()) ||
                    
                         item.SubItems[5].Text.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                        matchingItems.Add(item);
                    }
                }

                // Loại bỏ các mục không thỏa mãn khỏi danh sách
                listP.Items.Clear();
                listP.Items.AddRange(matchingItems.ToArray());

                if (listP.SelectedItems.Count == 1)
                {
                    listP.Focus();
                }


            }
            else
            {
                RefreshAll();
            }
        }
        private void RefreshAll()
        {
            HienThiDSP();
        }

        private void HienThiChiTietVatTu(string start,string end)
        {
            List<string> vatTuList = new List<string>();
            string query = "SELECT tenvt FROM vattuyte";
            SqlCommand cmd = new SqlCommand(query, sqlconnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vatTuList.Add(reader.GetString(0));
            }
            reader.Close();

            // Lấy danh sách các phòng từ bảng phongmo
            List<string> phongList = new List<string>();
            query = "SELECT id, tenphongmo FROM phongmo order by tenphongmo";
            cmd = new SqlCommand(query, sqlconnection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                phongList.Add(reader.GetInt32(0).ToString() + " - " + reader.GetString(1));
            }
            reader.Close();
            listViewvattu.Columns.Clear();

            // Tạo các cột cho listview
            ColumnHeader idColumnHeader = new ColumnHeader();
            idColumnHeader.Text = "ID";
            idColumnHeader.Width = 50;
            listViewvattu.Columns.Insert(0, idColumnHeader);

            ColumnHeader tenPhongColumnHeader = new ColumnHeader();
            tenPhongColumnHeader.Text = "Tên phòng mổ";
            tenPhongColumnHeader.Width = 150;
            listViewvattu.Columns.Insert(1, tenPhongColumnHeader);


            foreach (string vatTu in vatTuList)
            {
                listViewvattu.Columns.Add(vatTu, 100);
            }

            // Thêm các phòng vào listview và lấy số lượng vật tư tương ứng từ bảng chi tiết vật tư
            foreach (string phong in phongList)
            {
                string[] phongInfo = phong.Split('-'); // Tách id và tên phòng
                ListViewItem item = new ListViewItem(phongInfo[0].Trim()); // ID phòng
                item.SubItems.Add(phongInfo[1].Trim()); // Tên phòng
                query = "SELECT IDVatTuYTe, sl FROM chitietvattu INNER JOIN phongmo ON chitietvattu.IDPhongMo = phongmo.id INNER JOIN vattuyte ON chitietvattu.IDVatTuYTe = vattuyte.id WHERE phongmo.ID = @phong AND ngay >= @startDate AND ngay <= @endDate";
                cmd = new SqlCommand(query, sqlconnection);
                cmd.Parameters.AddWithValue("@phong", phongInfo[0].Trim());
                cmd.Parameters.AddWithValue("@startDate", start);
                cmd.Parameters.AddWithValue("@endDate", end);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int vatTuIndex = vatTuList.IndexOf(reader.GetInt32(0).ToString());
                    object soLuongObj = reader.GetValue(1);
                    int soLuong = (soLuongObj == DBNull.Value) ? 0 : Convert.ToInt32(soLuongObj);
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, soLuong.ToString());
                    item.SubItems.Add(subItem);
                }




                reader.Close();
                listViewvattu.Items.Add(item);
            }
        }

        private void dateTimestart_ValueChanged(object sender, EventArgs e)
        {
            listViewvattu.Items.Clear();
            DateTime start = dateTimestart.Value.Date;
            string formatstart = start.ToString("yyyy-MM-dd");
            DateTime end = dateTimeend.Value.Date;
            string formatend = end.ToString("yyyy-MM-dd");
            HienThiChiTietVatTu(formatstart,formatend);
        }

        private void listViewvattu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonin_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo một bảng tính trong tệp Excel
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                var worksheet = excel.Workbook.Worksheets.Add("TenBangTinh");

                // Lấy dữ liệu từ ListView và đưa chúng vào bảng tính Excel
                for(int i = 0; i < listP.Items.Count; i++)
{
                    for (int j = 0; j < listP.Columns.Count; j++)
                    {
                        if (i == 0) // Thêm tên cột vào dòng đầu tiên của bảng tính
                        {
                            worksheet.Cells[1, j + 1].Value = listP.Columns[j].Text;
                        }
                        string cellValue = listP.Items[i].SubItems[j].Text;
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1].Value = 0; // Hoặc "" nếu bạn muốn gán giá trị trống
                        }
                    }
                }


                // Lưu tệp Excel
                string filePath = @"D:\BVPT\QuanLyPhongMo\TenTepExcel.xlsx"; // Thay đổi đường dẫn tới thư mục lưu trữ của bạn
                FileInfo excelFile = new FileInfo(filePath);
                if (excelFile.Exists)
                {
                    excelFile.Delete(); // Xóa tệp nếu đã tồn tại để cập nhật lại dữ liệu mới
                    excelFile = new FileInfo("TenTepExcel.xlsx");
                }
                excel.SaveAs(excelFile);

                // Mở tệp Excel vừa tạo lên để xem

              
        Process.Start("TenTepExcel.xlsx");
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

                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT join TGMo as TGM  on LT.idTGMo = TGM.ID where IDNV = @idnv AND NgayTruc >= CONVERT(varchar, GETDATE(), 111)";
                }
                else
                {
                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT join TGMo as TGM  on LT.idTGMo = TGM.ID where IDNV = @idnv AND NgayTruc = '" + day + "'";
                }
                sqlcommand.Parameters.AddWithValue("@idnv", idnv);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                listViewLich.Items.Clear();
                while (reader.Read())
                {

                    DateTime NgayTruc = reader.GetDateTime(0);
                    string thu = NgayTruc.ToString("dddd", new CultureInfo("vi-VN")); // Lấy tên của ngày trong tuần từ cột NgayTruc
                    string TenTGMo = reader.GetString(1);
                    ListViewItem lvi = new ListViewItem(NgayTruc.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(thu); // Thêm giá trị của cột mới "Ngày trong tuần"
                    lvi.SubItems.Add(TenTGMo);
                    listViewLich.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePickerLT_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.ParseExact(dateTimePickerLT.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            LoadLichLam(selectedDate.Date.ToString());
        }

        private void DangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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


        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("D:\\test.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo một bảng tính trong tệp Excel
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = excel.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cột vào bảng tính
                int columnIndex = 1;
                foreach (ColumnHeader column in listP.Columns)
                {
                    worksheet.Cells[1, columnIndex++].Value = column.Text;
                }

                // Thêm dữ liệu vào bảng tính
                int rowIndex = 2;
                foreach (ListViewItem item in listP.Items)
                {
                    columnIndex = 1;
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        worksheet.Cells[rowIndex, columnIndex++].Value = subItem.Text;
                    }
                    rowIndex++;
                }

                // Lưu tệp Excel
                string filePath = @"C:\example.xlsx"; // Thay đổi đường dẫn tới thư mục lưu trữ của bạn
                FileInfo excelFile = new FileInfo(filePath);
                if (excelFile.Exists)
                {
                    excelFile.Delete(); // Xóa tệp nếu đã tồn tại để cập nhật lại dữ liệu mới
                    excelFile = new FileInfo(filePath);
                }
                excel.SaveAs(excelFile);

                // Mở tệp Excel vừa tạo lên để xem
                System.Diagnostics.Process.Start(filePath);
            }
        }


    }
}
