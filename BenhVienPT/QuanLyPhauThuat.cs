using BenhVienPT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BenhVienPT
{
    public partial class FormQuanLyPT : Form
    {
        //kết nối 
        static String connString = @"Data Source=TRANUY\SQLEXPRESS;Initial Catalog=WebBenhVienPT;User ID=sa;Password=123";
        //khai báo
        SqlConnection sqlconnection = new SqlConnection(connString);
        SqlCommand sqlcommand;
        private TaiKhoan acc;

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
        public FormQuanLyPT(Models.TaiKhoan acc)
        {
            this.acc = acc;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HienThiDSBenhAn();

            //  HienThiDSLichTruc();
            HienThiDSCaMo();
            LoadLichLam("");
            HienThiDSCaMoTC();
        }

       

        private void HienThiDSCaMo()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT DISTINCT bh.mabenhan, bn.TenBN, b.tenbenh, b.mucdo, bh.trangthai, b.id AS idBenh, bh.id AS idBenhAn, cm.id AS idCaMo, lm.Ngay, lm.camo, cm.IDPhongMo " +
                 "FROM benhan bh " +
                 "INNER JOIN CaMo cm ON cm.IDBenhAn = bh.ID " +
                 "INNER JOIN BenhNhan bn ON bn.ID = bh.IDBenhNhan " +
                 "INNER JOIN chitietbenhan cb ON bh.id = cb.idbenhan " +
                 "INNER JOIN benh b ON cb.idbenh = b.id " +
                 "INNER JOIN LichMo lm ON lm.IDCM = cm.id " +
                 "INNER JOIN (" +
                 "    SELECT cb.idbenhan, MAX(b.mucdo) AS max_mucdo " +
                 "    FROM chitietbenhan cb " +
                 "    INNER JOIN benh b ON cb.idbenh = b.id " +
                 "    GROUP BY cb.idbenhan" +
                 ") max_benh ON cb.idbenhan = max_benh.idbenhan AND b.mucdo = max_benh.max_mucdo " +
                 "WHERE bh.trangthai = 1 " +
                 "ORDER BY b.mucdo DESC";
                SqlDataReader reader = sqlcommand.ExecuteReader();
                livCaMo.Items.Clear();
                while (reader.Read())
                {
                    string MaBenhAn = reader.GetString(0);
                    string TenBenhNhan = reader.GetString(1);
                    string LoaiBenh = reader.GetString(2);
                    int mucDo = reader.GetInt32(3);
                    bool TrangThai = reader.GetBoolean(4);
                    int id = reader.GetInt32(5);
                    int idba = reader.GetInt32(6);
                    int idCaMo = reader.GetInt32(7);
                    DateTime ngay = reader.GetDateTime(8);
                    int iditgm = reader.GetInt32(9);
                    int ipm = reader.GetInt32(10);




                    ListViewItem lvi = new ListViewItem(MaBenhAn);
                    lvi.SubItems.Add(TenBenhNhan);
                    lvi.SubItems.Add(LoaiBenh);
                    lvi.SubItems.Add(mucDo.ToString());
                    lvi.SubItems.Add(TrangThai.ToString());
                    lvi.SubItems.Add(id.ToString());
                    lvi.SubItems.Add(idba.ToString());
                    lvi.SubItems.Add(idCaMo.ToString());
                    lvi.SubItems.Add(ngay.ToString("yyyy/MM/dd"));
                    lvi.SubItems.Add(iditgm.ToString());
                    lvi.SubItems.Add(ipm.ToString());


                    livCaMo.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiDSBenhAn()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "select BA.MaBenhAn, BN.TenBN, B.TenBenh, B.MucDo, BA.TrangThai, BA.GhiChu, BA.YLenh, BN.GioiTinh, BN.NgaySinh, BN.SDT  from BenhAn as BA inner join BenhNhan as BN on BA.IDBenhNhan = BN.ID inner join ChiTietBenhAn as CTBA on CTBA.IDBenhAn = BA.ID inner join Benh as B on B.ID = CTBA.IDBenh order by b.mucdo desc";
                SqlDataReader reader = sqlcommand.ExecuteReader();
                LivDSBenhAn.Items.Clear();
                while (reader.Read())
                {
                    string MaBenhAn = reader.GetString(0);
                    string TenBenhNhan = reader.GetString(1);
                    string LoaiBenh = reader.GetString(2);
                    int mucDo = reader.GetInt32(3);
                    bool TrangThai = reader.GetBoolean(4);
                    string GhiChu = reader.GetString(5);
                    string YLenh = reader.GetString(6);
                    string GioiTinh = reader.GetString(7);
                    DateTime NgaySinh = reader.GetDateTime(8);
                    string SDT = reader.GetString(9);          
           
                    ListViewItem lvi = new ListViewItem(MaBenhAn);
                    lvi.SubItems.Add(TenBenhNhan);
                    lvi.SubItems.Add(LoaiBenh);
                    lvi.SubItems.Add(mucDo.ToString());
                    lvi.SubItems.Add(TrangThai.ToString());
                    lvi.SubItems.Add(GhiChu);
                    lvi.SubItems.Add(YLenh);
                    lvi.SubItems.Add(GioiTinh);
                    lvi.SubItems.Add(NgaySinh.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(SDT);       

                    LivDSBenhAn.Items.Add(lvi);
                }
                reader.Close();

            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void LivDSBenhAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaBA.ReadOnly = true;
            txtMaBA.ReadOnly = true;
            txtTenBN.ReadOnly = true;
            txtLoaiBenh.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            txtGioiTinh.ReadOnly = true;
            txtNgaySinh.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtMucDo.ReadOnly = true;
            txtGhiChu.ReadOnly = true;
            txtYLenh.ReadOnly = true;
            if (LivDSBenhAn.SelectedItems.Count == 0) return;
            ListViewItem lvi = LivDSBenhAn.SelectedItems[0];
            txtMaBA.Text = lvi.SubItems[0].Text;
            txtTenBN.Text = lvi.SubItems[1].Text;
            txtLoaiBenh.Text = lvi.SubItems[2].Text;
            txtMucDo.Text = lvi.SubItems[3].Text;
            txtTrangThai.Text = lvi.SubItems[4].Text;
            txtGhiChu.Text = lvi.SubItems[5].Text;
            txtYLenh.Text = lvi.SubItems[6].Text;
            txtGioiTinh.Text = lvi.SubItems[7].Text;
            txtNgaySinh.Text = lvi.SubItems[8].Text;
            txtSDT.Text = lvi.SubItems[9].Text;
    
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

            if (txtTimKiem.Text != "")
            {
                // Tạo danh sách tạm thời chứa các mục thỏa mãn điều kiện tìm kiếm
                List<ListViewItem> matchingItems = new List<ListViewItem>();

                foreach (ListViewItem item in LivDSBenhAn.Items)
                {
                    if (item.SubItems[0].Text.ToLower().Contains(txtTimKiem.Text.ToLower()) ||
                        item.SubItems[1].Text.ToLower().Contains(txtTimKiem.Text.ToLower()) ||
                        item.SubItems[2].Text.ToLower().Contains(txtTimKiem.Text.ToLower()) ||
                         item.SubItems[3].Text.ToLower().Contains(txtTimKiem.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                        matchingItems.Add(item);
                    }
                }

                // Loại bỏ các mục không thỏa mãn khỏi danh sách
                LivDSBenhAn.Items.Clear();
                LivDSBenhAn.Items.AddRange(matchingItems.ToArray());

                if (LivDSBenhAn.SelectedItems.Count == 1)
                {
                    LivDSBenhAn.Focus();
                }
            

        }
            else
            {
                RefreshAll();
            }         

        }

        private void RefreshAll()
        {
            HienThiDSBenhAn();
        }



        private void lbTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          DialogResult y =  MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (y == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!");
                this.Hide();
                FormDangNhap logout = new FormDangNhap();
                logout.ShowDialog();
                this.Close();
            }
        }

        private void btnDatLich_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDatLich formdatlich = new FormDatLich(acc);
            formdatlich.ShowDialog();
            this.Close();
        }


private void txtTimKiemCaMo_TextChanged(object sender, EventArgs e)
    {
        if (txtTimKiemCaMo.Text != "")
        {
            // Tạo danh sách tạm thời chứa các mục thỏa mãn điều kiện tìm kiếm
            List<ListViewItem> matchingItems = new List<ListViewItem>();
            string pattern = txtTimKiemCaMo.Text.ToLower().Trim();
            string noAccentPattern = RemoveVietnameseAccent(pattern);
            Regex regex = new Regex(pattern);

            foreach (ListViewItem item in livCaMo.Items)
            {
                string text = item.SubItems[0].Text.ToLower();
                string noAccentText = RemoveVietnameseAccent(text);
                if (regex.IsMatch(text) || regex.IsMatch(noAccentText))
                {
                    item.BackColor = SystemColors.Highlight;
                    item.ForeColor = SystemColors.HighlightText;
                    matchingItems.Add(item);
                }
            }

            // Loại bỏ các mục không thỏa mãn khỏi danh sách
            livCaMo.Items.Clear();
            livCaMo.Items.AddRange(matchingItems.ToArray());

            if (livCaMo.SelectedItems.Count == 1)
            {
                livCaMo.Focus();
            }
        }
        else
        {
            RefreshAll1();
        }
    }

    private static string RemoveVietnameseAccent(string text)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string result = text.Normalize(NormalizationForm.FormD);
        result = regex.Replace(result, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        return result;
    }

    private void RefreshAll1()
        {
            HienThiDSCaMo();
        }

        private void livCaMo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cklBacSiCM.Items.Clear();
            cklYtaCM.Items.Clear();
            if (livCaMo.SelectedItems.Count == 0) return;
            ListViewItem lvi = livCaMo.SelectedItems[0];
            txtMaBACM.Text = lvi.SubItems[0].Text;
            txtTenBNCaMo.Text = lvi.SubItems[1].Text;
            string idtgm = livCaMo.SelectedItems[0].SubItems[9].Text;
            string idphong = livCaMo.SelectedItems[0].SubItems[10].Text;

            string idCaMo = livCaMo.SelectedItems[0].SubItems[7].Text;
            string idb = livCaMo.SelectedItems[0].SubItems[5].Text;
            string dinhdang = livCaMo.SelectedItems[0].SubItems[8].Text;

            

            HienThiThongTinCaMo(Convert.ToInt32(idCaMo));
            HienThiBS(Convert.ToInt32(idCaMo));
            HienThiYTa(Convert.ToInt32(idCaMo));
            HienThiDSPhongMo(idb,dinhdang);


        }

        private void HienThiThongTinCaMo(int idCaMo)
        {
            Openconn();
            string query = "SELECT DISTINCT lm.Ngay, lm.CaMo, pm.id, pm.TenPhongMo, tg.TenTGMo, pht.TenPhong " +
"FROM LichMo as lm " +
"INNER JOIN CaMo cm ON cm.ID = lm.IDCM " +
"INNER JOIN PhongMo pm ON pm.ID = cm.IDPhongMo " +
"INNER JOIN TGMo tg ON tg.id = lm.CaMo " +
"inner join PhongHoiTinh pht on pht.ID = cm.IDPhongHoiTinh " +
"WHERE cm.ID = @idCaMo"; 
            SqlCommand command = new SqlCommand(query, sqlconnection);
            command.Parameters.AddWithValue("@idCaMo", idCaMo);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DateTime ngay = reader.GetDateTime(0);
            dtpTGCaMo.Value = ngay;

            cbxPhongMoCM.Text = reader.GetString(3);
            cbxCaMoCM.Text = reader.GetString(4);
            cbxPhongHoiTinh.Text = reader.GetString(5);
            Closeconn();

            
        }
        private void HienThiBS(int idcamo)
        {
            Openconn();
            string query1 = "select distinct nv.tennv from lichmo as lm " +
                            "inner join camo cm on cm.id = lm.idcm " +
                            "inner join nhanvien nv on nv.id = lm.idnv " +
                            "inner join taikhoan tk on tk.id = nv.idtaikhoan " +
                            "inner join vaitro vt on vt.id = tk.idvaitro " +
                            "where cm.id = @idcamo and vt.id = 4";

            SqlCommand command1 = new SqlCommand(query1, sqlconnection);
            command1.Parameters.AddWithValue("@idcamo", idcamo);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    // assuming you have a checked list box named 'cklbacsicm'
                    cklBacSiCM.Items.Add(reader1["tennv"], true);
                }
            }
            reader1.Close();
        }

        private void HienThiYTa(int idcamo)
        {
            Openconn();
            string query1 = "select distinct nv.tennv from lichmo as lm " +
                            "inner join camo cm on cm.id = lm.idcm " +
                            "inner join nhanvien nv on nv.id = lm.idnv " +
                            "inner join taikhoan tk on tk.id = nv.idtaikhoan " +
                            "inner join vaitro vt on vt.id = tk.idvaitro " +
                            "where cm.id = @idcamo and vt.id = 2";

            SqlCommand command1 = new SqlCommand(query1, sqlconnection);
            command1.Parameters.AddWithValue("@idcamo", idcamo);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    // assuming you have a checked list box named 'cklbacsicm'
                    cklYtaCM.Items.Add(reader1["tennv"], true);
                }
            }
            reader1.Close();
        }
        private void HienThiDSPhongMo(string maBenh, string ngay)
        {
            Openconn();

            string query = "SELECT DISTINCT ctpm.IDPM, PM.TenPhongMo as Display FROM PhongMo as PM " +
                  "INNER JOIN ChiTietPhongBenh as CTPB ON CTPB.IDPM = PM.ID " +
                  "INNER JOIN Benh as B ON B.ID = CTPB.IDB " +
                  "INNER JOIN ChiTietPhongMo as ctpm on ctpm.IDPM = pm.id " +
                  "WHERE b.id = '" + maBenh + "' and ctpm.ngay = '" + ngay + "' and ctpm.TrangThai = 'false'";
            SqlCommand command = new SqlCommand(query, sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);



            if (table.Rows.Count > 0)
            {
                cbxPhongMoCM.DataSource = table;
                cbxPhongMoCM.ValueMember = "IDPM";
                cbxPhongMoCM.DisplayMember = "Display";
            }
            else
            {
                cbxPhongMoCM.DataSource = null;
            }


            // Đọc kết quả truy vấn và thêm các phòng còn trống vào ComboBox

        }
        private void HienThiDSCaMo(int maPM, string TGDatLich)
        {
            Openconn();

            string query = "SELECT CTPM.IDtgm as ID, TGM.TenTGMo FROM PhongMo as PM  INNER JOIN ChiTietPhongMo as CTPM ON CTPM.IDPM = PM.ID INNER JOIN TGMo as TGM ON TGM.ID = CTPM.IDTGM where CTPM.Ngay = '" + TGDatLich + "' and CTPM.TrangThai = 0 and PM.id = '" + maPM + "'";
            SqlCommand command = new SqlCommand(query, sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cbxCaMoCM.DataSource = table;
            cbxCaMoCM.ValueMember = "ID";
            cbxCaMoCM.DisplayMember = "TenTGMo";
        }

        private void cbxPhongMoCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime TGDatLich1 = dtpTGCaMo.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");
            int selectedID = 0;
            object selectedItem = cbxPhongMoCM.SelectedItem;
            if (selectedItem != null)
            {
                DataRowView row = (DataRowView)selectedItem;
                selectedID = Convert.ToInt32(row["IDPM"]);
                HienThiDSCaMo(selectedID, dinhdang);
            }
        }

        private void dtpChonNgayLT_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpChonNgayLT.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            LoadLichLam(formattedDate);
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

                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT  inner join TGMo as TGM  on lt.IDTGMo = tgm.ID where IDNV = @idnv AND NgayTruc >= CONVERT(varchar, GETDATE(), 111)";
                }
                else
                {
                    sqlcommand.CommandText = "SELECT  LT.NgayTruc, TGM.TenTGMo FROM LichTruc as LT join TGMo as TGM  on LT.IDTGMo = TGM.ID where IDNV = @idnv AND NgayTruc = '" + day + "'";
                }
                sqlcommand.Parameters.AddWithValue("@idnv", idnv);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                livLichTruc.Items.Clear();
                while (reader.Read())
                {

                    DateTime NgayTruc = reader.GetDateTime(0);
                    string thu = NgayTruc.ToString("dddd", new CultureInfo("vi-VN")); // Lấy tên của ngày trong tuần từ cột NgayTruc
                    string TenTGMo = reader.GetString(1);
                    ListViewItem lvi = new ListViewItem(NgayTruc.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(thu); // Thêm giá trị của cột mới "Ngày trong tuần"
                    lvi.SubItems.Add(TenTGMo);
                    livLichTruc.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string idba = livCaMo.SelectedItems[0].SubItems[6].Text;

            string idCaMo = livCaMo.SelectedItems[0].SubItems[7].Text;
            string idb = livCaMo.SelectedItems[0].SubItems[5].Text;
            string dinhdang = livCaMo.SelectedItems[0].SubItems[8].Text;
            string idtgm = livCaMo.SelectedItems[0].SubItems[9].Text;
            string idphong = livCaMo.SelectedItems[0].SubItems[10].Text;
            // Lấy danh sách các nhân viên được tick trong CheckedListBox BacSi
            List<string> selectedBacSi = cklBacSiCM.CheckedItems.OfType<string>().ToList();

            // Lấy danh sách các nhân viên được tick trong CheckedListBox Yta
            List<string> selectedYta = cklYtaCM.CheckedItems.OfType<string>().ToList();
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy ca mổ này không?", "Xác nhận hủy ca mổ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            try
            {
                Openconn();
                //xóa trong bảng lịch mổ
                string querydeleteCamo = "delete from lichmo where idcm = @idcm";
                SqlCommand commandInsertCamo = new SqlCommand(querydeleteCamo, sqlconnection);
                commandInsertCamo.Parameters.AddWithValue("@idcm", idCaMo);
                commandInsertCamo.ExecuteNonQuery();
                //xóa trong bảng camo
                string querydeletelichmo = "delete from camo where id = @idcm";
                SqlCommand commanddeletelichmo = new SqlCommand(querydeletelichmo, sqlconnection);
                commanddeletelichmo.Parameters.AddWithValue("@idcm", idCaMo);
                commanddeletelichmo.ExecuteNonQuery();
                //update bảng chitietphongmo
                string queryUpdateChiTietPhongMo = "UPDATE ChiTietPhongMo SET TrangThai = 'false' WHERE IDPM = @idphongmo AND ngay = @ngay and idtgm = @idtgm";
                SqlCommand commandUpdateChiTietPhongMo = new SqlCommand(queryUpdateChiTietPhongMo, sqlconnection);
                commandUpdateChiTietPhongMo.Parameters.AddWithValue("@idphongmo", idphong);
                commandUpdateChiTietPhongMo.Parameters.AddWithValue("@ngay", dinhdang);
                commandUpdateChiTietPhongMo.Parameters.AddWithValue("@idtgm", idtgm);
                commandUpdateChiTietPhongMo.ExecuteNonQuery();
                //update benhan
                string queryUpdatebenhan = "UPDATE benhan SET TrangThai = 'false' WHERE id = @idphongmo ";
                SqlCommand commandUpdatebenhan = new SqlCommand(queryUpdatebenhan, sqlconnection);
                commandUpdatebenhan.Parameters.AddWithValue("@idphongmo", idba);


                commandUpdatebenhan.ExecuteNonQuery();
                //update  lichtruc
                foreach (string nv in selectedBacSi)
                {
                    string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                    SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                    cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                    int idNV = (int)cmdSelectNV.ExecuteScalar();
                    // Cập nhật trạng thái cho bảng lichtruc
                    string queryUpdateLichTruc = "UPDATE lichtruc SET TrangThai = 'false' WHERE IDNV = @idnv AND Ngaytruc = @ngay AND idtgmo = @ca";
                    SqlCommand commandUpdateLichTruc = new SqlCommand(queryUpdateLichTruc, sqlconnection);
                    commandUpdateLichTruc.Parameters.AddWithValue("@idnv", idNV);
                    commandUpdateLichTruc.Parameters.AddWithValue("@ngay", dinhdang);
                    commandUpdateLichTruc.Parameters.AddWithValue("@ca", idtgm);
                    commandUpdateLichTruc.ExecuteNonQuery();
                }
                foreach (string nv in selectedYta)
                {
                    string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                    SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                    cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                    int idNV = (int)cmdSelectNV.ExecuteScalar();
                    // Cập nhật trạng thái cho bảng lichtruc
                    string queryUpdateLichTruc = "UPDATE lichtruc SET TrangThai = 'false' WHERE IDNV = @idnv AND Ngaytruc = @ngay AND idtgmo = @ca";
                    SqlCommand commandUpdateLichTruc = new SqlCommand(queryUpdateLichTruc, sqlconnection);
                    commandUpdateLichTruc.Parameters.AddWithValue("@idnv", idNV);
                    commandUpdateLichTruc.Parameters.AddWithValue("@ngay", dinhdang);
                    commandUpdateLichTruc.Parameters.AddWithValue("@ca", idtgm);
                    commandUpdateLichTruc.ExecuteNonQuery();
                        MessageBox.Show("Hủy ca mổ thành công");
                        cbxPhongMoCM.SelectedIndex = -1;
                        cbxCaMoCM.SelectedIndex = -1;
                        cbxPhongHoiTinh.SelectedIndex = -1;
                        cklBacSiCM.Items.Clear();
                        cklYtaCM.Items.Clear();
                    }
                HienThiDSCaMo();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void HienThiDSCaMoTC()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT cm.macamo, cm.tencamo, bn.tenbn, pht.tenphong, ba.ghichu, ba.ylenh, ba.id " +
                                            "FROM CaMo cm " +
                                            "INNER JOIN BenhAn ba ON ba.ID = cm.IDBenhAn " +
                                            "INNER JOIN PhongHoiTinh pht ON pht.ID = cm.IDPhongHoiTinh " +
                                            "INNER JOIN BenhNhan bn ON bn.ID = ba.IDBenhNhan " +
                                            "WHERE cm.TinhTrang = 1";
                SqlDataReader reader = sqlcommand.ExecuteReader();
                livCaMoTC.Items.Clear();
                while (reader.Read())
                {
                    string MaCaMo = reader.GetString(0);
                    string TenCaMo = reader.GetString(1);
                    string TenBN = reader.GetString(2);
                    string TenPhong = reader.GetString(3);
                    string GhiChu = reader.GetString(4);
                    string YLenh = reader.GetString(5);
                    int idba = reader.GetInt32(6);


                    ListViewItem lvi = new ListViewItem(MaCaMo);
                    lvi.SubItems.Add(TenCaMo);
                    lvi.SubItems.Add(TenBN);
                    lvi.SubItems.Add(TenPhong);
                    lvi.SubItems.Add(GhiChu);
                    lvi.SubItems.Add(YLenh);
                    lvi.SubItems.Add(idba.ToString());

                    livCaMoTC.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void livCaMoTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (livCaMoTC.SelectedItems.Count == 0) return;
            ListViewItem lvi = livCaMoTC.SelectedItems[0];
            txtmacamo.Text = lvi.SubItems[0].Text;
            txttencamo.Text = lvi.SubItems[1].Text;
            txttenbenhnhan.Text = lvi.SubItems[2].Text;
            txtphonghoitinh.Text = lvi.SubItems[3].Text;
            txtghichucm.Text = lvi.SubItems[4].Text;
            txtylenhcm.Text = lvi.SubItems[5].Text;
            txtidbacm.Text = lvi.SubItems[6].Text;
        }

        private void btnLuuCM_Click(object sender, EventArgs e)
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "UPDATE BenhAn SET GhiChu = @GhiChu, YLenh = @YLenh WHERE id = @idba";
                sqlcommand.Parameters.AddWithValue("@GhiChu", txtghichucm.Text);
                sqlcommand.Parameters.AddWithValue("@YLenh", txtylenhcm.Text);
                sqlcommand.Parameters.AddWithValue("@idba", txtidbacm.Text);
                int kq = sqlcommand.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công !");
                    HienThiDSCaMoTC();
                    this.txtidbacm.Clear();
                    this.txtmacamo.Clear();
                    this.txttencamo.Clear();
                    this.txttenbenhnhan.Clear();
                    this.txtphonghoitinh.Clear();
                    this.txtghichucm.Clear();
                    this.txtylenhcm.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txttimkiemcm_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemCaMo.Text != "")
            {
                // Tạo danh sách tạm thời chứa các mục thỏa mãn điều kiện tìm kiếm
                List<ListViewItem> matchingItems = new List<ListViewItem>();

                foreach (ListViewItem item in livCaMoTC.Items)
                {
                    if (item.SubItems[0].Text.ToLower().Contains(txtTimKiemCaMo.Text.ToLower()) ||
                        item.SubItems[1].Text.ToLower().Contains(txtTimKiemCaMo.Text.ToLower()) ||
                        item.SubItems[2].Text.ToLower().Contains(txtTimKiemCaMo.Text.ToLower()) ||
                         item.SubItems[3].Text.ToLower().Contains(txtTimKiemCaMo.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                        matchingItems.Add(item);
                    }
                }

                // Loại bỏ các mục không thỏa mãn khỏi danh sách
                livCaMoTC.Items.Clear();
                livCaMoTC.Items.AddRange(matchingItems.ToArray());

                if (livCaMoTC.SelectedItems.Count == 1)
                {
                    livCaMoTC.Focus();
                }


            }
            else
            {
                RefreshAll2();
            }
        }

        private void RefreshAll2()
        {
            HienThiDSCaMoTC();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiDSBenhAn();
        }
    }

}

