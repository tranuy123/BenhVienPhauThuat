using BenhVienPT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BenhVienPT
{
    public partial class FormDatLich : Form
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

        public FormDatLich(Models.TaiKhoan acc)
        {
            InitializeComponent();
        }

        private void FormChiTiet_Load(object sender, EventArgs e)
        {
            DateTime TGDatLich = dtpTGDatLich.Value;
            HienThiDSBADatLich();
            HienThiPhongHoiTinh();

         //   HienThiDSCaMo(maPM, TGDatLich);
        }

        private void HienThiPhongHoiTinh()
        {
            Openconn();
            string query = "select ID, TenPhong from PhongHoiTinh where TrangThai = 1";
            SqlCommand command = new SqlCommand(query, sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            cbxPhongHoiTinh.DataSource = dataTable;
            cbxPhongHoiTinh.DisplayMember = "TenPhong"; // Tên của cột muốn hiển thị trong combobox
            cbxPhongHoiTinh.ValueMember = "ID"; // Tên của cột muốn lấy giá trị khi chọn item trong combobox
            reader.Close();
            Closeconn();
        }

        private void HienThiDSBADatLich()
        {
            try
            {
                Openconn();
                sqlcommand = sqlconnection.CreateCommand();
                sqlcommand.CommandText = "SELECT bh.mabenhan, bn.TenBN , b.tenbenh, b.mucdo , bh.trangthai, b.id,bh.id " +
                    "FROM benhan bh " +
                    "INNER JOIN BenhNhan bn on bn.ID = bh.IDBenhNhan " +
                    "INNER JOIN chitietbenhan cb ON bh.id = cb.idbenhan " +
                    "INNER JOIN benh b ON cb.idbenh = b.id " +
                    "INNER JOIN ( " +
                        "SELECT cb.idbenhan, MAX(b.mucdo) AS max_mucdo " +
                        "FROM chitietbenhan cb " +
                        "INNER JOIN benh b ON cb.idbenh = b.id " +
                        "GROUP BY cb.idbenhan " +
                    ") max_benh ON cb.idbenhan = max_benh.IDBenhAn AND b.mucdo = max_benh.max_mucdo " +
                    "where trangthai= 0 " +
                    "ORDER BY b.mucdo desc";
                SqlDataReader reader = sqlcommand.ExecuteReader();
                livDatLich.Items.Clear();
                while (reader.Read())
                {
                    string MaBenhAn = reader.GetString(0);
                    string TenBenhNhan = reader.GetString(1);
                    string LoaiBenh = reader.GetString(2);
                    int mucDo = reader.GetInt32(3);
                    bool TrangThai = reader.GetBoolean(4);
                    int id = reader.GetInt32(5);
                    int idba = reader.GetInt32(6);



                    ListViewItem lvi = new ListViewItem(MaBenhAn);
                    lvi.SubItems.Add(TenBenhNhan);
                    lvi.SubItems.Add(LoaiBenh);
                    lvi.SubItems.Add(mucDo.ToString());
                    lvi.SubItems.Add(TrangThai.ToString());
                    lvi.SubItems.Add(id.ToString());
                    lvi.SubItems.Add(idba.ToString());


                    livDatLich.Items.Add(lvi);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiDSPhongMo( string maBenh,string ngay)
        {
            Openconn();
            
            string query = "SELECT DISTINCT ctpm.IDPM, PM.TenPhongMo as Display FROM PhongMo as PM " +
                  "INNER JOIN ChiTietPhongBenh as CTPB ON CTPB.IDPM = PM.ID " +
                  "INNER JOIN Benh as B ON B.ID = CTPB.IDB " +
                  "INNER JOIN ChiTietPhongMo as ctpm on ctpm.IDPM = pm.id " +
                  "WHERE b.id = '"+maBenh+"' and ctpm.ngay = '"+ngay+"' and ctpm.TrangThai = 'false'";
            SqlCommand command = new SqlCommand(query, sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

           

            if (table.Rows.Count > 0)
            {
                cbxPhongMo.DataSource = table;
                cbxPhongMo.ValueMember = "IDPM";
                cbxPhongMo.DisplayMember = "Display";
            }
            else
            {
                cbxPhongMo.DataSource = null;
            }

            // Đọc kết quả truy vấn và thêm các phòng còn trống vào ComboBox

        }

        // Khai báo biến toàn cục
        
        private void livDatLich_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime TGDatLich1 = dtpTGDatLich.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");

            if (livDatLich.SelectedItems.Count > 0)
            {
                string idbenh = livDatLich.SelectedItems[0].SubItems[5].Text;
                // Xóa các phần tử đang có trong cbxPhongMo
                cbxPhongMo.DataSource = null;
                cbxPhongMo.Items.Clear();

                HienThiDSPhongMo(idbenh,dinhdang);
                textBoxidb.Clear();
                textBoxidb.Text = idbenh;

                    cbxCaMo.SelectedIndex = -1;
            }
           

            if (livDatLich.SelectedItems.Count == 0) return;
            ListViewItem lvi = livDatLich.SelectedItems[0];
            txtMaBA.Text = lvi.SubItems[0].Text;
            txtTenBN.Text = lvi.SubItems[1].Text;
        }

        private void HienThiDSCaMo(int maPM, string TGDatLich)
        {
            Openconn();
            
            string query = "SELECT CTPM.IDtgm as ID, TGM.TenTGMo FROM PhongMo as PM  INNER JOIN ChiTietPhongMo as CTPM ON CTPM.IDPM = PM.ID INNER JOIN TGMo as TGM ON TGM.ID = CTPM.IDTGM where CTPM.Ngay = '"+ TGDatLich + "' and CTPM.TrangThai = 0 and PM.id = '"+maPM+"'";
            SqlCommand command = new SqlCommand(query, sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cbxCaMo.DataSource = table;
            cbxCaMo.ValueMember = "ID";
            cbxCaMo.DisplayMember = "TenTGMo";
        }

        private void cbxPhongMo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime TGDatLich1 = dtpTGDatLich.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");
            int selectedID = 0;
            object selectedItem = cbxPhongMo.SelectedItem;
            if (selectedItem != null)
            {
                DataRowView row = (DataRowView)selectedItem;
                selectedID = Convert.ToInt32(row["IDPM"]);
                HienThiDSCaMo(selectedID, dinhdang);
            }




        }

        

        private void dtpTGDatLich_ValueChanged(object sender, EventArgs e)
        {
            DateTime TGDatLich1 = dtpTGDatLich.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");
            int selectedID = 0;
            string idbenh = textBoxidb.Text;
            object selectedItem = cbxPhongMo.SelectedItem;
            if (selectedItem != null)
            {
                DataRowView row = (DataRowView)selectedItem;
                selectedID = Convert.ToInt32(row["IDPM"]);
                HienThiDSCaMo(selectedID, dinhdang);
            }
            if (idbenh != null)
            {
                HienThiDSPhongMo(idbenh, dinhdang);
            }
            else
            {
                HienThiDSPhongMo("", dinhdang);

            }

        }

        private void cbxCaMo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIDPM = 0;
            int selectedIDCM = 0;

            DateTime TGDatLich1 = dtpTGDatLich.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");
            object selectedItem = cbxPhongMo.SelectedItem;
            DataRowView row = (DataRowView)selectedItem;
            if (row != null)
            {
                selectedIDPM = Convert.ToInt32(row["IDPM"]);
            }
            else
            {
                selectedIDPM = 0;
            }
            object selectedItem1 = cbxCaMo.SelectedItem;
            DataRowView row1 = (DataRowView)selectedItem1;
            if (row1 != null)
            {
                selectedIDCM = Convert.ToInt32(row1["ID"]);
            }
            else
            {
                selectedIDCM = 0;            
            }


            // Khai báo danh sách các record đã có sẵn
            // Khai báo danh sách các record đã có sẵn
            List<string> recordsBacSi = new List<string>();
            List<string> recordsYta = new List<string>();

            try
            {
                // Mở kết nối
                Openconn();

                // Khai báo đối tượng SqlCommand
                string queryBacSi = "select nv.TenNV from lichtruc as l inner join nhanvien nv on nv.id = l.idnv where l.NgayTruc = @NgayTruc and l.IDTGMo = @IDTGMo and l.TrangThai = 0 and idvt = 4";
                SqlCommand cmdBacSi = new SqlCommand(queryBacSi, sqlconnection);
                cmdBacSi.Parameters.AddWithValue("@NgayTruc", dinhdang);
                cmdBacSi.Parameters.AddWithValue("@IDTGMo", selectedIDCM);

                string queryYta = "select nv.TenNV from lichtruc as l inner join nhanvien nv on nv.id = l.idnv where l.NgayTruc = @NgayTruc and l.IDTGMo = @IDTGMo and l.TrangThai = 0 and idvt = 2";
                SqlCommand cmdYta = new SqlCommand(queryYta, sqlconnection);
                cmdYta.Parameters.AddWithValue("@NgayTruc", dinhdang);
                cmdYta.Parameters.AddWithValue("@IDTGMo", selectedIDCM);

                // Khai báo đối tượng SqlDataReader
                using (SqlDataReader readerBacSi = cmdBacSi.ExecuteReader())
                {
                    // Đọc dữ liệu từ SqlDataReader và thêm vào danh sách records
                    while (readerBacSi.Read())
                    {
                        string recordBacSi = readerBacSi.GetString(readerBacSi.GetOrdinal("TenNV"));
                        recordsBacSi.Add(recordBacSi);
                    }

                    // Gán danh sách các record vào DataSource của CheckedListBox
                    cklBacSi.DataSource = recordsBacSi;
                }

                using (SqlDataReader readerYta = cmdYta.ExecuteReader())
                {
                    // Đọc dữ liệu từ SqlDataReader và thêm vào danh sách records
                    while (readerYta.Read())
                    {
                        string recordYta = readerYta.GetString(readerYta.GetOrdinal("TenNV"));
                        recordsYta.Add(recordYta);
                    }

                    // Gán danh sách các record vào DataSource của CheckedListBox
                    cklYta.DataSource = recordsYta;
                }
            }
            finally
            {
                // Đóng kết nối
                Closeconn();
            }





        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            DateTime TGDatLich1 = dtpTGDatLich.Value.Date;
            string dinhdang = TGDatLich1.ToString("yyyy-MM-dd");
            string idba = livDatLich.SelectedItems[0].SubItems[6].Text;

            int idpht = 0;
            int selectedID = 0;
            int selectedIDCM = 0;
            object selectedItem2 = cbxPhongHoiTinh.SelectedItem;
            DataRowView row2 = (DataRowView)selectedItem2;
            idpht = Convert.ToInt32(row2["ID"]);

            if (cbxPhongMo.SelectedItem == null)
            {
                MessageBox.Show("Phòng mổ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                object selectedItem = cbxPhongMo.SelectedItem;
                DataRowView row = (DataRowView)selectedItem;
                selectedID = Convert.ToInt32(row["IDPM"]);
            }


            object selectedItem1 = cbxCaMo.SelectedItem;
            DataRowView row1 = (DataRowView)selectedItem1;
            if (row1 != null)
            {
                selectedIDCM = Convert.ToInt32(row1["ID"]);
            }
            else
            {
                selectedIDCM = 0;
            }


            if (cbxCaMo.SelectedItem == null)
            {
                MessageBox.Show("Ca mổ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cklBacSi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn bác sĩ!");
                return;
            }
            if (cklYta.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn y tá!");
                return;
            }
            else
            {
                try
                {
                    Openconn();

                    string queryInsertCamo = "INSERT INTO camo (idphongmo, idbenhan, idphonghoitinh) VALUES (@idphongmo, @idbenhan, @idphonghoitinh); SELECT SCOPE_IDENTITY();";
                    SqlCommand commandInsertCamo = new SqlCommand(queryInsertCamo, sqlconnection);
                    commandInsertCamo.Parameters.AddWithValue("@idphongmo", selectedID);
                    commandInsertCamo.Parameters.AddWithValue("@idbenhan", idba);
                    commandInsertCamo.Parameters.AddWithValue("@idphonghoitinh", idpht);
                    int insertedCamoId = Convert.ToInt32(commandInsertCamo.ExecuteScalar());

                    // Thêm dữ liệu vào bảng lichmo
                    // Lấy danh sách các nhân viên được tick trong CheckedListBox BacSi
                    List<string> selectedBacSi = cklBacSi.CheckedItems.OfType<string>().ToList();

                    // Lấy danh sách các nhân viên được tick trong CheckedListBox Yta
                    List<string> selectedYta = cklYta.CheckedItems.OfType<string>().ToList();

                    // Thêm dữ liệu vào bảng lichmo cho từng nhân viên được tick
                    foreach (string nv in selectedBacSi)
                    {
                        // Lấy id của nhân viên được tick từ bảng NhanVien
                        string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                        SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                        cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                        int idNV = (int)cmdSelectNV.ExecuteScalar();

                        // Thêm dữ liệu vào bảng lichmo
                        string queryInsertLichMo = "INSERT INTO lichmo (idcm, idnv, camo, ngay) VALUES (@idcamo, @idnv, @idtgm, @ngay)";
                        SqlCommand commandInsertLichMo = new SqlCommand(queryInsertLichMo, sqlconnection);
                        commandInsertLichMo.Parameters.AddWithValue("@idcamo", insertedCamoId);
                        commandInsertLichMo.Parameters.AddWithValue("@idnv", idNV);
                        commandInsertLichMo.Parameters.AddWithValue("@idtgm", selectedIDCM);
                        commandInsertLichMo.Parameters.AddWithValue("@ngay", dinhdang);
                        commandInsertLichMo.ExecuteNonQuery();
                    }

                    foreach (string nv in selectedYta)
                    {
                        // Lấy id của nhân viên được tick từ bảng NhanVien
                        string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                        SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                        cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                        int idNV = (int)cmdSelectNV.ExecuteScalar();

                        // Thêm dữ liệu vào bảng lichmo
                        string queryInsertLichMo = "INSERT INTO lichmo (idcm, idnv, camo, ngay) VALUES (@idcamo, @idnv, @idtgm, @ngay)";
                        SqlCommand commandInsertLichMo = new SqlCommand(queryInsertLichMo, sqlconnection);
                        commandInsertLichMo.Parameters.AddWithValue("@idcamo", insertedCamoId);
                        commandInsertLichMo.Parameters.AddWithValue("@idnv", idNV);
                        commandInsertLichMo.Parameters.AddWithValue("@idtgm", selectedIDCM);
                        commandInsertLichMo.Parameters.AddWithValue("@ngay", dinhdang);
                        commandInsertLichMo.ExecuteNonQuery();
                    }


                    // Cập nhật trạng thái cho bảng chitietphongmo
                    string queryUpdateChiTietPhongMo = "UPDATE ChiTietPhongMo SET TrangThai = 'true' WHERE IDPM = @idphongmo AND ngay = @ngay and idtgm = @idtgm";
                    SqlCommand commandUpdateChiTietPhongMo = new SqlCommand(queryUpdateChiTietPhongMo, sqlconnection);
                    commandUpdateChiTietPhongMo.Parameters.AddWithValue("@idphongmo", selectedID);
                    commandUpdateChiTietPhongMo.Parameters.AddWithValue("@ngay", dinhdang);
                    commandUpdateChiTietPhongMo.Parameters.AddWithValue("@idtgm", selectedIDCM);

                    //
                    string queryUpdatebenhan = "UPDATE benhan SET TrangThai = 'true' WHERE id = @idphongmo ";
                    SqlCommand commandUpdatebenhan = new SqlCommand(queryUpdatebenhan, sqlconnection);
                    commandUpdatebenhan.Parameters.AddWithValue("@idphongmo", idba);


                    commandUpdatebenhan.ExecuteNonQuery();

                    foreach (string nv in selectedBacSi)
                    {
                        string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                        SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                        cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                        int idNV = (int)cmdSelectNV.ExecuteScalar();
                        // Cập nhật trạng thái cho bảng lichtruc
                        string queryUpdateLichTruc = "UPDATE lichtruc SET TrangThai = 'true' WHERE IDNV = @idnv AND Ngaytruc = @ngay AND idtgmo = @ca";
                        SqlCommand commandUpdateLichTruc = new SqlCommand(queryUpdateLichTruc, sqlconnection);
                        commandUpdateLichTruc.Parameters.AddWithValue("@idnv", idNV);
                        commandUpdateLichTruc.Parameters.AddWithValue("@ngay", dinhdang);
                        commandUpdateLichTruc.Parameters.AddWithValue("@ca", selectedIDCM);
                        commandUpdateLichTruc.ExecuteNonQuery();
                    }
                    foreach (string nv in selectedYta)
                    {
                        string querySelectNV = "SELECT id FROM nhanvien WHERE TenNV = @TenNV";
                        SqlCommand cmdSelectNV = new SqlCommand(querySelectNV, sqlconnection);
                        cmdSelectNV.Parameters.AddWithValue("@TenNV", nv);
                        int idNV = (int)cmdSelectNV.ExecuteScalar();
                        // Cập nhật trạng thái cho bảng lichtruc
                        string queryUpdateLichTruc = "UPDATE lichtruc SET TrangThai = 'true' WHERE IDNV = @idnv AND Ngaytruc = @ngay AND idtgmo = @ca";
                        SqlCommand commandUpdateLichTruc = new SqlCommand(queryUpdateLichTruc, sqlconnection);
                        commandUpdateLichTruc.Parameters.AddWithValue("@idnv", idNV);
                        commandUpdateLichTruc.Parameters.AddWithValue("@ngay", dinhdang);
                        commandUpdateLichTruc.Parameters.AddWithValue("@ca", selectedIDCM);
                        commandUpdateLichTruc.ExecuteNonQuery();
                    }
                    HienThiDSBADatLich();

                    MessageBox.Show("Thêm thành công");
                    cbxPhongMo.SelectedIndex = -1;
                    cbxCaMo.SelectedIndex = -1;
                    cbxPhongHoiTinh.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

           
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult y = MessageBox.Show("Bạn có muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (y == DialogResult.Yes)
            {
                this.Hide();
                FormQuanLyPT qlpt = new FormQuanLyPT(acc);
                qlpt.ShowDialog();
                this.Close();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

            if (txtTimKiem.Text != "")
            {
                // Tạo danh sách tạm thời chứa các mục thỏa mãn điều kiện tìm kiếm
                List<ListViewItem> matchingItems = new List<ListViewItem>();

                foreach (ListViewItem item in livDatLich.Items)
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
                livDatLich.Items.Clear();
                livDatLich.Items.AddRange(matchingItems.ToArray());

                if (livDatLich.SelectedItems.Count == 1)
                {
                    livDatLich.Focus();
                }


            }
            else
            {
                RefreshAll();
            }

        }

        private void RefreshAll()
        {
            HienThiDSBADatLich();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
