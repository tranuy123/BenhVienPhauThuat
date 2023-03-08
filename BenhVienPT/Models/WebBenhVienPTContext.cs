using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class WebBenhVienPTContext : DbContext
    {
        public WebBenhVienPTContext()
        {
        }

        public WebBenhVienPTContext(DbContextOptions<WebBenhVienPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benh> Benh { get; set; }
        public virtual DbSet<BenhAn> BenhAn { get; set; }
        public virtual DbSet<BenhNhan> BenhNhan { get; set; }
        public virtual DbSet<CaMo> CaMo { get; set; }
        public virtual DbSet<ChiTietBenhAn> ChiTietBenhAn { get; set; }
        public virtual DbSet<ChiTietPhongBenh> ChiTietPhongBenh { get; set; }
        public virtual DbSet<ChiTietPhongMo> ChiTietPhongMo { get; set; }
        public virtual DbSet<ChiTietVatTu> ChiTietVatTu { get; set; }
        public virtual DbSet<LichMo> LichMo { get; set; }
        public virtual DbSet<LichTruc> LichTruc { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongHoiTinh> PhongHoiTinh { get; set; }
        public virtual DbSet<PhongMo> PhongMo { get; set; }
        public virtual DbSet<PhongMoKt> PhongMoKt { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<Tgmo> Tgmo { get; set; }
        public virtual DbSet<VaiTro> VaiTro { get; set; }
        public virtual DbSet<VatTuYte> VatTuYte { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRANUY\\SQLEXPRESS;Database=WebBenhVienPT;User Id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benh>(entity =>
            {
                entity.HasIndex(e => e.MaBenh)
                    .HasName("UQ__Benh__DB7E2D482B8ABFB9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaBenh).HasMaxLength(50);

                entity.Property(e => e.TenBenh).HasMaxLength(500);
            });

            modelBuilder.Entity<BenhAn>(entity =>
            {
                entity.HasIndex(e => new { e.IdbenhNhan, e.MaBenhAn })
                    .HasName("UQ__BenhAn__C7660BDC3E3285EE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.IdbenhNhan).HasColumnName("IDBenhNhan");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.MaBenhAn).HasMaxLength(50);

                entity.Property(e => e.Ylenh)
                    .HasColumnName("YLenh")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdbenhNhanNavigation)
                    .WithMany(p => p.BenhAn)
                    .HasForeignKey(d => d.IdbenhNhan)
                    .HasConstraintName("FK_BenhAn_BenhNhan");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.BenhAn)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_BenhAn_NhanVien");
            });

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasIndex(e => e.MaBn)
                    .HasName("UQ__BenhNhan__272475ACC0A2749A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.MaBn)
                    .HasColumnName("MaBN")
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenBn)
                    .HasColumnName("TenBN")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<CaMo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdbenhAn).HasColumnName("IDBenhAn");

                entity.Property(e => e.IdphongHoiTinh).HasColumnName("IDPhongHoiTinh");

                entity.Property(e => e.IdphongMo).HasColumnName("IDPhongMo");

                entity.Property(e => e.MaCaMo).HasMaxLength(50);

                entity.Property(e => e.TenCaMo).HasMaxLength(50);

                entity.HasOne(d => d.IdbenhAnNavigation)
                    .WithMany(p => p.CaMo)
                    .HasForeignKey(d => d.IdbenhAn)
                    .HasConstraintName("FK_CaMo_BenhAn");

                entity.HasOne(d => d.IdphongHoiTinhNavigation)
                    .WithMany(p => p.CaMo)
                    .HasForeignKey(d => d.IdphongHoiTinh)
                    .HasConstraintName("FK_CaMo_PhongHoiTinh");

                entity.HasOne(d => d.IdphongMoNavigation)
                    .WithMany(p => p.CaMo)
                    .HasForeignKey(d => d.IdphongMo)
                    .HasConstraintName("FK_CaMo_PhongMo");
            });

            modelBuilder.Entity<ChiTietBenhAn>(entity =>
            {
                entity.HasIndex(e => e.MaCtba)
                    .HasName("UQ__ChiTietB__1EB6F2890B89FC59")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idbenh).HasColumnName("IDBenh");

                entity.Property(e => e.IdbenhAn).HasColumnName("IDBenhAn");

                entity.Property(e => e.MaCtba)
                    .HasColumnName("MaCTBA")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdbenhNavigation)
                    .WithMany(p => p.ChiTietBenhAn)
                    .HasForeignKey(d => d.Idbenh)
                    .HasConstraintName("FK_ChiTietBenhAn_Benh");

                entity.HasOne(d => d.IdbenhAnNavigation)
                    .WithMany(p => p.ChiTietBenhAn)
                    .HasForeignKey(d => d.IdbenhAn)
                    .HasConstraintName("FK_ChiTietBenhAn_BenhAn");
            });

            modelBuilder.Entity<ChiTietPhongBenh>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idb).HasColumnName("IDB");

                entity.Property(e => e.Idpm).HasColumnName("IDPM");

                entity.Property(e => e.MaCtb)
                    .HasColumnName("MaCTB")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdbNavigation)
                    .WithMany(p => p.ChiTietPhongBenh)
                    .HasForeignKey(d => d.Idb)
                    .HasConstraintName("FK_ChiTietPhongBenh_Benh");

                entity.HasOne(d => d.IdpmNavigation)
                    .WithMany(p => p.ChiTietPhongBenh)
                    .HasForeignKey(d => d.Idpm)
                    .HasConstraintName("FK_ChiTietPhongBenh_PhongMo");
            });

            modelBuilder.Entity<ChiTietPhongMo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpm).HasColumnName("IDPM");

                entity.Property(e => e.Idtgm).HasColumnName("IDTGM");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.IdpmNavigation)
                    .WithMany(p => p.ChiTietPhongMo)
                    .HasForeignKey(d => d.Idpm)
                    .HasConstraintName("FK_ChiTietPhongMo_PhongMo");

                entity.HasOne(d => d.IdtgmNavigation)
                    .WithMany(p => p.ChiTietPhongMo)
                    .HasForeignKey(d => d.Idtgm)
                    .HasConstraintName("FK_ChiTietPhongMo_TGMo");
            });

            modelBuilder.Entity<ChiTietVatTu>(entity =>
            {
                entity.HasIndex(e => e.MaCtvt)
                    .HasName("UQ__ChiTietV__1E4FF6AB43AAD913")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.IdphongMo).HasColumnName("IDPhongMo");

                entity.Property(e => e.IdvatTuYte).HasColumnName("IDVatTuYTe");

                entity.Property(e => e.MaCtvt)
                    .HasColumnName("MaCTVT")
                    .HasMaxLength(50);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.Sl).HasColumnName("sl");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.ChiTietVatTu)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_ChiTietVatTu_NhanVien");

                entity.HasOne(d => d.IdphongMoNavigation)
                    .WithMany(p => p.ChiTietVatTu)
                    .HasForeignKey(d => d.IdphongMo)
                    .HasConstraintName("FK_ChiTietVatTu_PhongMo");

                entity.HasOne(d => d.IdvatTuYteNavigation)
                    .WithMany(p => p.ChiTietVatTu)
                    .HasForeignKey(d => d.IdvatTuYte)
                    .HasConstraintName("FK_ChiTietVatTu_VatTuYTe");
            });

            modelBuilder.Entity<LichMo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idcm).HasColumnName("IDCM");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.MaLm)
                    .HasColumnName("MaLM")
                    .HasMaxLength(50);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.IdcmNavigation)
                    .WithMany(p => p.LichMo)
                    .HasForeignKey(d => d.Idcm)
                    .HasConstraintName("FK_LichMo_CaMo");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.LichMo)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_LichMo_NhanVien");
            });

            modelBuilder.Entity<LichTruc>(entity =>
            {
                entity.HasIndex(e => e.MaLich)
                    .HasName("UQ__LichTruc__728A9AE89BBBA5D8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Idtgmo).HasColumnName("IDTGMo");

                entity.Property(e => e.Idvt).HasColumnName("IDVT");

                entity.Property(e => e.MaLich).HasMaxLength(50);

                entity.Property(e => e.NgayTruc).HasColumnType("date");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.LichTruc)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_LichTruc_NhanVien");

                entity.HasOne(d => d.IdtgmoNavigation)
                    .WithMany(p => p.LichTruc)
                    .HasForeignKey(d => d.Idtgmo)
                    .HasConstraintName("FK_LichTruc_TGMo");

                entity.HasOne(d => d.IdvtNavigation)
                    .WithMany(p => p.LichTruc)
                    .HasForeignKey(d => d.Idvt)
                    .HasConstraintName("FK_LichTruc_VaiTro");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasIndex(e => e.MaNv)
                    .HasName("UQ__NhanVien__2725D70B0B9AD340")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.IdtaiKhoan).HasColumnName("IDTaiKhoan");

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenNv)
                    .HasColumnName("TenNV")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdtaiKhoanNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.IdtaiKhoan)
                    .HasConstraintName("FK_NhanVien_TaiKhoan");
            });

            modelBuilder.Entity<PhongHoiTinh>(entity =>
            {
                entity.HasIndex(e => e.MaPhongHt)
                    .HasName("UQ__PhongHoi__F46B5961B2F2E11D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaPhongHt)
                    .HasColumnName("MaPhongHT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenPhong).HasMaxLength(50);
            });

            modelBuilder.Entity<PhongMo>(entity =>
            {
                entity.HasIndex(e => e.MaPhongMo)
                    .HasName("UQ__PhongMo__F46D0F946C8624DF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Loai).HasMaxLength(50);

                entity.Property(e => e.MaPhongMo).HasMaxLength(50);

                entity.Property(e => e.TenPhongMo).HasMaxLength(500);
            });

            modelBuilder.Entity<PhongMoKt>(entity =>
            {
                entity.ToTable("PhongMoKT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdphongMo).HasColumnName("IDPhongMo");

                entity.Property(e => e.Idtgmo).HasColumnName("IDTGMo");

                entity.Property(e => e.TenPhongMo).HasMaxLength(50);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasIndex(e => e.TaiKhoan1)
                    .HasName("UQ__TaiKhoan__D5B8C7F0404DACBC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdvaiTro).HasColumnName("IDVaiTro");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan1)
                    .HasColumnName("TaiKhoan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdvaiTroNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.IdvaiTro)
                    .HasConstraintName("FK_TaiKhoan_VaiTro");
            });

            modelBuilder.Entity<Tgmo>(entity =>
            {
                entity.ToTable("TGMo");

                entity.HasIndex(e => e.MaTgmo)
                    .HasName("UQ__TGMo__B4049151BA96EB4F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaTgmo)
                    .HasColumnName("MaTGMo")
                    .HasMaxLength(50);

                entity.Property(e => e.TenTgmo)
                    .HasColumnName("TenTGMo")
                    .HasMaxLength(50);

                entity.Property(e => e.TgbatDau).HasColumnName("TGBatDau");

                entity.Property(e => e.TgketThuc).HasColumnName("TGKetThuc");
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasIndex(e => e.MaVt)
                    .HasName("UQ__VaiTro__2725103FF9A3154B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaVt)
                    .HasColumnName("MaVT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenVaiTro).HasMaxLength(50);
            });

            modelBuilder.Entity<VatTuYte>(entity =>
            {
                entity.ToTable("VatTuYTe");

                entity.HasIndex(e => e.MaVt)
                    .HasName("UQ__VatTuYTe__2725103F11BBF0CC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaVt)
                    .HasColumnName("MaVT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenVt)
                    .HasColumnName("TenVT")
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
