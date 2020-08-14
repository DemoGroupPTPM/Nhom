using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLCHDT_API.Models
{
    public partial class Ql_CuaHangDT_AndroidContext : DbContext
    {
        public Ql_CuaHangDT_AndroidContext()
        {
        }

        public Ql_CuaHangDT_AndroidContext(DbContextOptions<Ql_CuaHangDT_AndroidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loaihang> Loaihang { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=KIMHUNG\\SQLEXPRESS;Initial Catalog=Ql_CuaHangDT_Android;User ID=sa;Password=sa2012");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Masp });

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.Mahd)
                    .HasColumnName("MAHD")
                    .HasMaxLength(50);

                entity.Property(e => e.Masp)
                    .HasColumnName("MASP")
                    .HasMaxLength(50);

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("money");

                entity.Property(e => e.Donvitinh)
                    .HasColumnName("DONVITINH")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'Cái')");

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("MAKHACHHANG")
                    .HasMaxLength(50);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Thanhtien)
                    .HasColumnName("THANHTIEN")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADON_SANPHAM");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("MAKHACHHANG")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Diachi).HasColumnName("DIACHI");

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Tenkhachhang)
                    .HasColumnName("TENKHACHHANG")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Loaihang>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAIHANG");

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloai)
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Mancc);

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Chuthich)
                    .HasColumnName("CHUTHICH")
                    .HasMaxLength(100);

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tenncc)
                    .HasColumnName("TENNCC")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp);

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Masp)
                    .HasColumnName("MASP")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Baohanh)
                    .HasColumnName("BAOHANH")
                    .HasMaxLength(50);

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("money");

                entity.Property(e => e.Hinhanh).HasColumnName("HINHANH");

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasMaxLength(50);

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasMaxLength(50);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenhang)
                    .HasColumnName("TENHANG")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_SANPHAM_LOAIHANG");

                entity.HasOne(d => d.ManccNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.Mancc)
                    .HasConstraintName("FK_SANPHAM_NHACUNGCAP");
            });
        }
    }
}
