﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Library.Models.ChiTietMuonTra", b =>
                {
                    b.Property<int>("MaMuonTra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("DaTra")
                        .HasColumnType("bit");

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaSach")
                        .HasColumnType("int");

                    b.Property<int?>("MuonTraMa")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SachMaSach")
                        .HasColumnType("int");

                    b.HasKey("MaMuonTra");

                    b.HasIndex("MuonTraMa");

                    b.HasIndex("SachMaSach");

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

                    b.Property<int>("MaThe")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("TenDocGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TheThuVienMa")
                        .HasColumnType("int");

                    b.HasKey("Ma");

                    b.HasIndex("TheThuVienMa");

                    b.ToTable("DocGias");
                });

            modelBuilder.Entity("Library.Models.MuonTra", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int>("MaThe")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVienMa")
                        .HasColumnType("int");

                    b.Property<int?>("TheThuVienMa")
                        .HasColumnType("int");

                    b.HasKey("Ma");

                    b.HasIndex("NhanVienMa");

                    b.HasIndex("TheThuVienMa");

                    b.ToTable("MuonTras");
                });

            modelBuilder.Entity("Library.Models.NhaXuatBan", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma");

                    b.ToTable("NhaXuatBans");
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
                    b.Property<int>("MaSach")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaNhaXuatBan")
                        .HasColumnType("int");

                    b.Property<int>("MaTheLoai")
                        .HasColumnType("int");

                    b.Property<int>("MatacGia")
                        .HasColumnType("int");

                    b.Property<int>("NamXuatBan")
                        .HasColumnType("int");

                    b.Property<int?>("NhaXuatBanMa")
                        .HasColumnType("int");

                    b.Property<int?>("TacGiaMa")
                        .HasColumnType("int");

                    b.Property<string>("TenSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TheLoaiMa")
                        .HasColumnType("int");

                    b.HasKey("MaSach");

                    b.HasIndex("NhaXuatBanMa");

                    b.HasIndex("TacGiaMa");

                    b.HasIndex("TheLoaiMa");

                    b.ToTable("Saches");
                });

            modelBuilder.Entity("Library.Models.TacGia", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma");

                    b.ToTable("TacGias");
                });

            modelBuilder.Entity("Library.Models.TheLoai", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ma");

                    b.ToTable("TheLoais");
                });

            modelBuilder.Entity("Library.Models.TheThuVien", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.HasKey("Ma");

                    b.ToTable("TheThuViens");
                });

            modelBuilder.Entity("Library.Models.ChiTietMuonTra", b =>
                {
                    b.HasOne("Library.Models.MuonTra", "MuonTra")
                        .WithMany()
                        .HasForeignKey("MuonTraMa");

                    b.HasOne("Library.Models.Sach", "Sach")
                        .WithMany("ChiTietMuonTras")
                        .HasForeignKey("SachMaSach");

                    b.Navigation("MuonTra");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("Library.Models.DocGia", b =>
                {
                    b.HasOne("Library.Models.TheThuVien", "TheThuVien")
                        .WithMany()
                        .HasForeignKey("TheThuVienMa");

                    b.Navigation("TheThuVien");
                });

            modelBuilder.Entity("Library.Models.MuonTra", b =>
                {
                    b.HasOne("Library.Models.NhanVien", "NhanVien")
                        .WithMany("MuonTras")
                        .HasForeignKey("NhanVienMa");

                    b.HasOne("Library.Models.TheThuVien", "TheThuVien")
                        .WithMany()
                        .HasForeignKey("TheThuVienMa");

                    b.Navigation("NhanVien");

                    b.Navigation("TheThuVien");
                });

            modelBuilder.Entity("Library.Models.Sach", b =>
                {
                    b.HasOne("Library.Models.NhaXuatBan", "NhaXuatBan")
                        .WithMany("Saches")
                        .HasForeignKey("NhaXuatBanMa");

                    b.HasOne("Library.Models.TacGia", "TacGia")
                        .WithMany("Saches")
                        .HasForeignKey("TacGiaMa");

                    b.HasOne("Library.Models.TheLoai", "TheLoai")
                        .WithMany("Saches")
                        .HasForeignKey("TheLoaiMa");

                    b.Navigation("NhaXuatBan");

                    b.Navigation("TacGia");

                    b.Navigation("TheLoai");
                });

            modelBuilder.Entity("Library.Models.NhaXuatBan", b =>
                {
                    b.Navigation("Saches");
                });

            modelBuilder.Entity("Library.Models.NhanVien", b =>
                {
                    b.Navigation("MuonTras");
                });

            modelBuilder.Entity("Library.Models.Sach", b =>
                {
                    b.Navigation("ChiTietMuonTras");
                });

            modelBuilder.Entity("Library.Models.TacGia", b =>
                {
                    b.Navigation("Saches");
                });

            modelBuilder.Entity("Library.Models.TheLoai", b =>
                {
                    b.Navigation("Saches");
                });
#pragma warning restore 612, 618
        }
    }
}
