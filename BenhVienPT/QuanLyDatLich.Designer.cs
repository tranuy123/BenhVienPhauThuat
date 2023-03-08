
namespace BenhVienPT
{
    partial class FormDatLich
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.livDatLich = new System.Windows.Forms.ListView();
            this.MaBA = new System.Windows.Forms.ColumnHeader();
            this.TenBN = new System.Windows.Forms.ColumnHeader();
            this.TenB = new System.Windows.Forms.ColumnHeader();
            this.MucDo = new System.Windows.Forms.ColumnHeader();
            this.TrangThai = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxidb = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxPhongHoiTinh = new System.Windows.Forms.ComboBox();
            this.cklYta = new System.Windows.Forms.CheckedListBox();
            this.btnluu = new System.Windows.Forms.Button();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cklBacSi = new System.Windows.Forms.CheckedListBox();
            this.txtMaBA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCaMo = new System.Windows.Forms.ComboBox();
            this.cbxPhongMo = new System.Windows.Forms.ComboBox();
            this.dtpTGDatLich = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 46);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(449, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐẶT LỊCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 597);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(511, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 597);
            this.panel4.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.livDatLich);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.Brown;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 597);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin bệnh án cần đặt lịch";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTimKiem);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(654, 60);
            this.panel5.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(121, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(509, 30);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Brown;
            this.label10.Location = new System.Drawing.Point(18, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tìm kiếm:";
            // 
            // livDatLich
            // 
            this.livDatLich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livDatLich.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaBA,
            this.TenBN,
            this.TenB,
            this.MucDo,
            this.TrangThai});
            this.livDatLich.FullRowSelect = true;
            this.livDatLich.GridLines = true;
            this.livDatLich.HideSelection = false;
            this.livDatLich.Location = new System.Drawing.Point(3, 86);
            this.livDatLich.Name = "livDatLich";
            this.livDatLich.Size = new System.Drawing.Size(654, 508);
            this.livDatLich.TabIndex = 0;
            this.livDatLich.UseCompatibleStateImageBehavior = false;
            this.livDatLich.View = System.Windows.Forms.View.Details;
            this.livDatLich.SelectedIndexChanged += new System.EventHandler(this.livDatLich_SelectedIndexChanged);
            // 
            // MaBA
            // 
            this.MaBA.Text = "Mã bệnh án";
            this.MaBA.Width = 120;
            // 
            // TenBN
            // 
            this.TenBN.Text = "Tên bệnh nhân";
            this.TenBN.Width = 150;
            // 
            // TenB
            // 
            this.TenB.Text = "Loại bệnh";
            this.TenB.Width = 150;
            // 
            // MucDo
            // 
            this.MucDo.Text = "Mức độ";
            this.MucDo.Width = 100;
            // 
            // TrangThai
            // 
            this.TrangThai.Text = "Trạng thái";
            this.TrangThai.Width = 120;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 597);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxidb);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbxPhongHoiTinh);
            this.groupBox1.Controls.Add(this.cklYta);
            this.groupBox1.Controls.Add(this.btnluu);
            this.groupBox1.Controls.Add(this.txtTenBN);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cklBacSi);
            this.groupBox1.Controls.Add(this.txtMaBA);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxCaMo);
            this.groupBox1.Controls.Add(this.cbxPhongMo);
            this.groupBox1.Controls.Add(this.dtpTGDatLich);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 597);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đặt lịch";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxidb
            // 
            this.textBoxidb.Location = new System.Drawing.Point(38, 43);
            this.textBoxidb.Name = "textBoxidb";
            this.textBoxidb.Size = new System.Drawing.Size(63, 30);
            this.textBoxidb.TabIndex = 17;
            this.textBoxidb.Visible = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.Control;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Location = new System.Drawing.Point(356, 521);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(131, 54);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(34, 473);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "Phòng hồi tỉnh:";
            // 
            // cbxPhongHoiTinh
            // 
            this.cbxPhongHoiTinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxPhongHoiTinh.FormattingEnabled = true;
            this.cbxPhongHoiTinh.Location = new System.Drawing.Point(188, 469);
            this.cbxPhongHoiTinh.Name = "cbxPhongHoiTinh";
            this.cbxPhongHoiTinh.Size = new System.Drawing.Size(299, 30);
            this.cbxPhongHoiTinh.TabIndex = 14;
            // 
            // cklYta
            // 
            this.cklYta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cklYta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cklYta.FormattingEnabled = true;
            this.cklYta.Location = new System.Drawing.Point(188, 371);
            this.cklYta.Name = "cklYta";
            this.cklYta.Size = new System.Drawing.Size(299, 75);
            this.cklYta.TabIndex = 13;
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnluu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnluu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnluu.ForeColor = System.Drawing.Color.White;
            this.btnluu.Location = new System.Drawing.Point(188, 521);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(162, 54);
            this.btnluu.TabIndex = 12;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // txtTenBN
            // 
            this.txtTenBN.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenBN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenBN.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTenBN.ForeColor = System.Drawing.Color.Navy;
            this.txtTenBN.Location = new System.Drawing.Point(333, 61);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.ReadOnly = true;
            this.txtTenBN.Size = new System.Drawing.Size(154, 27);
            this.txtTenBN.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Brown;
            this.label8.Location = new System.Drawing.Point(188, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tên bệnh nhân:";
            // 
            // cklBacSi
            // 
            this.cklBacSi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cklBacSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cklBacSi.FormattingEnabled = true;
            this.cklBacSi.Location = new System.Drawing.Point(188, 274);
            this.cklBacSi.Name = "cklBacSi";
            this.cklBacSi.Size = new System.Drawing.Size(299, 75);
            this.cklBacSi.TabIndex = 9;
            // 
            // txtMaBA
            // 
            this.txtMaBA.BackColor = System.Drawing.SystemColors.Control;
            this.txtMaBA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaBA.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMaBA.ForeColor = System.Drawing.Color.Navy;
            this.txtMaBA.Location = new System.Drawing.Point(333, 24);
            this.txtMaBA.Name = "txtMaBA";
            this.txtMaBA.ReadOnly = true;
            this.txtMaBA.Size = new System.Drawing.Size(154, 27);
            this.txtMaBA.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(34, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y tá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(34, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ca mổ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(34, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phòng mổ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bác sĩ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(188, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Mã bệnh án:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thời gian:";
            // 
            // cbxCaMo
            // 
            this.cbxCaMo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxCaMo.FormattingEnabled = true;
            this.cbxCaMo.Location = new System.Drawing.Point(188, 219);
            this.cbxCaMo.Name = "cbxCaMo";
            this.cbxCaMo.Size = new System.Drawing.Size(299, 30);
            this.cbxCaMo.TabIndex = 4;
            this.cbxCaMo.SelectedIndexChanged += new System.EventHandler(this.cbxCaMo_SelectedIndexChanged);
            // 
            // cbxPhongMo
            // 
            this.cbxPhongMo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxPhongMo.FormattingEnabled = true;
            this.cbxPhongMo.Location = new System.Drawing.Point(188, 160);
            this.cbxPhongMo.Name = "cbxPhongMo";
            this.cbxPhongMo.Size = new System.Drawing.Size(299, 30);
            this.cbxPhongMo.TabIndex = 3;
            this.cbxPhongMo.SelectedIndexChanged += new System.EventHandler(this.cbxPhongMo_SelectedIndexChanged);
            // 
            // dtpTGDatLich
            // 
            this.dtpTGDatLich.CustomFormat = "dd/MM/yyyy";
            this.dtpTGDatLich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGDatLich.Location = new System.Drawing.Point(188, 101);
            this.dtpTGDatLich.Name = "dtpTGDatLich";
            this.dtpTGDatLich.Size = new System.Drawing.Size(299, 30);
            this.dtpTGDatLich.TabIndex = 0;
            this.dtpTGDatLich.Value = new System.DateTime(2023, 3, 8, 14, 41, 28, 0);
            this.dtpTGDatLich.ValueChanged += new System.EventHandler(this.dtpTGDatLich_ValueChanged);
            // 
            // FormDatLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 643);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDatLich";
            this.Text = "Form Đặt Lịch";
            this.Load += new System.EventHandler(this.FormChiTiet_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTGDatLich;
        private System.Windows.Forms.ComboBox cbxPhongMo;
        private System.Windows.Forms.ComboBox cbxCaMo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaBA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox cklBacSi;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.CheckedListBox cklYta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxPhongHoiTinh;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView livDatLich;
        private System.Windows.Forms.ColumnHeader MaBA;
        private System.Windows.Forms.ColumnHeader TenBN;
        private System.Windows.Forms.ColumnHeader TenB;
        private System.Windows.Forms.ColumnHeader MucDo;
        private System.Windows.Forms.ColumnHeader TrangThai;
        private System.Windows.Forms.TextBox textBoxidb;
    }
}