
namespace BenhVienPT
{
    partial class Yta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.tabCtrlHT = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.liVPhongHT = new System.Windows.Forms.ListView();
            this.MaBenhAn = new System.Windows.Forms.ColumnHeader();
            this.TenBenhNhan = new System.Windows.Forms.ColumnHeader();
            this.GhiChu = new System.Windows.Forms.ColumnHeader();
            this.TrangThai = new System.Windows.Forms.ColumnHeader();
            this.YLenh = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.txtYLenh = new System.Windows.Forms.TextBox();
            this.txtMaBA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpngaytruc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.liVlichLV = new System.Windows.Forms.ListView();
            this.NgayTruc = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.TenTGMo = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.liVCaMo = new System.Windows.Forms.ListView();
            this.TenCaMo = new System.Windows.Forms.ColumnHeader();
            this.Ngay = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.TenPhongMo = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.TenBN = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabCtrlHT.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlHT
            // 
            this.tabCtrlHT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrlHT.Controls.Add(this.tabPage1);
            this.tabCtrlHT.Controls.Add(this.tabPage2);
            this.tabCtrlHT.Controls.Add(this.tabPage3);
            this.tabCtrlHT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabCtrlHT.Location = new System.Drawing.Point(4, 52);
            this.tabCtrlHT.Name = "tabCtrlHT";
            this.tabCtrlHT.SelectedIndex = 0;
            this.tabCtrlHT.Size = new System.Drawing.Size(1150, 636);
            this.tabCtrlHT.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTimKiem);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1142, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bệnh án";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(253, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(359, 18);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(549, 34);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.liVPhongHT);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 537);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bệnh án";
            // 
            // liVPhongHT
            // 
            this.liVPhongHT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liVPhongHT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaBenhAn,
            this.TenBenhNhan,
            this.GhiChu,
            this.TrangThai,
            this.YLenh});
            this.liVPhongHT.FullRowSelect = true;
            this.liVPhongHT.GridLines = true;
            this.liVPhongHT.HideSelection = false;
            this.liVPhongHT.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.liVPhongHT.Location = new System.Drawing.Point(3, 23);
            this.liVPhongHT.Name = "liVPhongHT";
            this.liVPhongHT.Size = new System.Drawing.Size(605, 511);
            this.liVPhongHT.TabIndex = 2;
            this.liVPhongHT.UseCompatibleStateImageBehavior = false;
            this.liVPhongHT.View = System.Windows.Forms.View.Details;
            this.liVPhongHT.SelectedIndexChanged += new System.EventHandler(this.liVPhongHT_SelectedIndexChanged);
            // 
            // MaBenhAn
            // 
            this.MaBenhAn.Text = "Mã bệnh án";
            this.MaBenhAn.Width = 120;
            // 
            // TenBenhNhan
            // 
            this.TenBenhNhan.Text = "Bệnh nhân";
            this.TenBenhNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TenBenhNhan.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.Text = "Ghi chú";
            this.GhiChu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GhiChu.Width = 120;
            // 
            // TrangThai
            // 
            this.TrangThai.Text = "Trạng thái";
            this.TrangThai.Width = 120;
            // 
            // YLenh
            // 
            this.YLenh.Text = "Y lệnh";
            this.YLenh.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.txtTenBN);
            this.groupBox2.Controls.Add(this.txtYLenh);
            this.groupBox2.Controls.Add(this.txtMaBA);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.ForeColor = System.Drawing.Color.Brown;
            this.groupBox2.Location = new System.Drawing.Point(614, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 521);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(130, 208);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(354, 185);
            this.txtGhiChu.TabIndex = 2;
            // 
            // txtTenBN
            // 
            this.txtTenBN.Location = new System.Drawing.Point(130, 108);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.ReadOnly = true;
            this.txtTenBN.Size = new System.Drawing.Size(354, 30);
            this.txtTenBN.TabIndex = 2;
            // 
            // txtYLenh
            // 
            this.txtYLenh.Location = new System.Drawing.Point(130, 158);
            this.txtYLenh.Name = "txtYLenh";
            this.txtYLenh.ReadOnly = true;
            this.txtYLenh.Size = new System.Drawing.Size(354, 30);
            this.txtYLenh.TabIndex = 2;
            // 
            // txtMaBA
            // 
            this.txtMaBA.Location = new System.Drawing.Point(130, 58);
            this.txtMaBA.Name = "txtMaBA";
            this.txtMaBA.ReadOnly = true;
            this.txtMaBA.Size = new System.Drawing.Size(354, 30);
            this.txtMaBA.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "Y lệnh:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(15, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bệnh nhân:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ghi chú:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bệnh án:";
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(130, 432);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(115, 67);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Chỉnh sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(372, 432);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(112, 67);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtpngaytruc);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.liVlichLV);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1142, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lịch làm việc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpngaytruc
            // 
            this.dtpngaytruc.CustomFormat = "dd/MM/yyyy";
            this.dtpngaytruc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaytruc.Location = new System.Drawing.Point(213, 31);
            this.dtpngaytruc.Name = "dtpngaytruc";
            this.dtpngaytruc.Size = new System.Drawing.Size(289, 30);
            this.dtpngaytruc.TabIndex = 3;
            this.dtpngaytruc.Value = new System.DateTime(2023, 3, 8, 15, 19, 32, 0);
            this.dtpngaytruc.ValueChanged += new System.EventHandler(this.dtpngaytruc_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(94, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Chọn ngày:";
            // 
            // liVlichLV
            // 
            this.liVlichLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liVlichLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NgayTruc,
            this.columnHeader1,
            this.TenTGMo});
            this.liVlichLV.GridLines = true;
            this.liVlichLV.HideSelection = false;
            this.liVlichLV.Location = new System.Drawing.Point(4, 89);
            this.liVlichLV.Name = "liVlichLV";
            this.liVlichLV.Size = new System.Drawing.Size(1132, 506);
            this.liVlichLV.TabIndex = 0;
            this.liVlichLV.UseCompatibleStateImageBehavior = false;
            this.liVlichLV.View = System.Windows.Forms.View.Details;
            // 
            // NgayTruc
            // 
            this.NgayTruc.Text = "Ngày Trực";
            this.NgayTruc.Width = 400;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Thứ";
            this.columnHeader1.Width = 400;
            // 
            // TenTGMo
            // 
            this.TenTGMo.Text = "Ca trực";
            this.TenTGMo.Width = 400;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.dateTimePicker2);
            this.tabPage3.Controls.Add(this.liVCaMo);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1142, 601);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ca mổ tham gia";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Brown;
            this.label9.Location = new System.Drawing.Point(137, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 22);
            this.label9.TabIndex = 2;
            this.label9.Text = "Chọn ngày:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(251, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(362, 30);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2023, 3, 8, 15, 20, 16, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged_1);
            // 
            // liVCaMo
            // 
            this.liVCaMo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liVCaMo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenCaMo,
            this.Ngay,
            this.columnHeader2,
            this.TenPhongMo,
            this.columnHeader3,
            this.TenBN});
            this.liVCaMo.GridLines = true;
            this.liVCaMo.HideSelection = false;
            this.liVCaMo.Location = new System.Drawing.Point(5, 73);
            this.liVCaMo.Name = "liVCaMo";
            this.liVCaMo.Size = new System.Drawing.Size(1128, 522);
            this.liVCaMo.TabIndex = 0;
            this.liVCaMo.UseCompatibleStateImageBehavior = false;
            this.liVCaMo.View = System.Windows.Forms.View.Details;
            // 
            // TenCaMo
            // 
            this.TenCaMo.Text = "Tên Ca Mổ";
            this.TenCaMo.Width = 120;
            // 
            // Ngay
            // 
            this.Ngay.Text = "Ngày";
            this.Ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ngay.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ca Mổ";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // TenPhongMo
            // 
            this.TenPhongMo.Text = "Phòng Mổ";
            this.TenPhongMo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TenPhongMo.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bệnh án";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // TenBN
            // 
            this.TenBN.Text = "Bệnh nhân";
            this.TenBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TenBN.Width = 120;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(397, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "BỆNH ÁN SAU PHẨU THUẬT";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 52);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.Location = new System.Drawing.Point(1024, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 22);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng xuất";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // Yta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 690);
            this.Controls.Add(this.tabCtrlHT);
            this.Controls.Add(this.panel1);
            this.Name = "Yta";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            this.tabCtrlHT.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlHT;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView liVlichLV;
        private System.Windows.Forms.ColumnHeader NgayTruc;
        private System.Windows.Forms.ListView liVPhongHT;
        private System.Windows.Forms.ColumnHeader MaBenhAn;
        private System.Windows.Forms.ColumnHeader TenBenhNhan;
        private System.Windows.Forms.ColumnHeader GhiChu;
        private System.Windows.Forms.ColumnHeader TenTGMo;
        private System.Windows.Forms.ColumnHeader TrangThai;
        private System.Windows.Forms.ColumnHeader YLenh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpngaytruc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.TextBox txtYLenh;
        private System.Windows.Forms.TextBox txtMaBA;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView liVCaMo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ColumnHeader TenCaMo;
        private System.Windows.Forms.ColumnHeader Ngay;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader TenPhongMo;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader TenBN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}