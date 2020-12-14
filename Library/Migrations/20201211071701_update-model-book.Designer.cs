﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201211071701_update-model-book")]
    partial class updatemodelbook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Library.Models.ChiTietMuonTra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("DaTra")
                        .HasColumnType("bit");

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MuonTraMa")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<string>("SachID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SachID1")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MuonTraMa");

                    b.HasIndex("SachID1");

                    b.ToTable("ChiTietMuonTras");
                });

            modelBuilder.Entity("Library.Models.DocGia", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaSinhVien")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("TenDocGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma");

                    b.ToTable("DocGias");
                });

            modelBuilder.Entity("Library.Models.MuonTra", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DocGiaMa")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhanVienMa")
                        .HasColumnType("int");

                    b.HasKey("Ma");

                    b.HasIndex("DocGiaMa");

                    b.HasIndex("NhanVienMa");

                    b.ToTable("MuonTras");
                });

            modelBuilder.Entity("Library.Models.NganhHoc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("NganhHocs");
                });

            modelBuilder.Entity("Library.Models.NhanVien", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("Library.Models.Sach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NamXuatBan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhapKho")
                        .HasColumnType("datetime2");

                    b.Property<string>("NhaXuatBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TacGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Saches");
                });

            modelBuilder.Entity("Library.Models.SachHong", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LyDo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBaoHong")
                        .HasColumnType("datetime2");

                    b.Property<int>("SachID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongHong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SachID")
                        .IsUnique();

                    b.ToTable("SachHongs");
                });

            modelBuilder.Entity("Library.Models.Sach_Nganh", b =>
                {
                    b.Property<int>("NganhID")
                        .HasColumnType("int");

                    b.Property<int>("SachID")
                        .HasColumnType("int");

                    b.HasKey("NganhID", "SachID");

                    b.HasIndex("SachID");

                    b.ToTable("Sach_Nganhs");
                });

            modelBuilder.Entity("Library.Models.ThongBao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("NgayThongBao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhanVienMa")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("NhanVienMa");

                    b.ToTable("ThongBaos");
                });

            modelBuilder.Entity("Library.Models.ChiTietMuonTra", b =>
                {
                    b.HasOne("Library.Models.MuonTra", "MuonTra")
                        .WithMany()
                        .HasForeignKey("MuonTraMa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Sach", "Sach")
                        .WithMany("ChiTietMuonTras")
                        .HasForeignKey("SachID1");

                    b.Navigation("MuonTra");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("Library.Models.MuonTra", b =>
                {
                    b.HasOne("Library.Models.DocGia", "DocGia")
                        .WithMany()
                        .HasForeignKey("DocGiaMa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.NhanVien", "NhanVien")
                        .WithMany("MuonTras")
                        .HasForeignKey("NhanVienMa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocGia");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Library.Models.SachHong", b =>
                {
                    b.HasOne("Library.Models.Sach", "Sach")
                        .WithOne("SachHong")
                        .HasForeignKey("Library.Models.SachHong", "SachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("Library.Models.Sach_Nganh", b =>
                {
                    b.HasOne("Library.Models.NganhHoc", "Nganh")
                        .WithMany("Sach_Nganhs")
                        .HasForeignKey("NganhID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Sach", "Sach")
                        .WithMany("Sach_Nganhs")
                        .HasForeignKey("SachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nganh");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("Library.Models.ThongBao", b =>
                {
                    b.HasOne("Library.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("NhanVienMa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Library.Models.NganhHoc", b =>
                {
                    b.Navigation("Sach_Nganhs");
                });

            modelBuilder.Entity("Library.Models.NhanVien", b =>
                {
                    b.Navigation("MuonTras");
                });

            modelBuilder.Entity("Library.Models.Sach", b =>
                {
                    b.Navigation("ChiTietMuonTras");

                    b.Navigation("Sach_Nganhs");

                    b.Navigation("SachHong");
                });
#pragma warning restore 612, 618
        }
    }
}
