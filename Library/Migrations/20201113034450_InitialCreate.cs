using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<int>(type: "int", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBans",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBans", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "TacGias",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGias", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "TheLoais",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoais", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "TheThuViens",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheThuViens", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "Saches",
                columns: table => new
                {
                    MaSach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatacGia = table.Column<int>(type: "int", nullable: false),
                    MaTheLoai = table.Column<int>(type: "int", nullable: false),
                    MaNhaXuatBan = table.Column<int>(type: "int", nullable: false),
                    NamXuatBan = table.Column<int>(type: "int", nullable: false),
                    TacGiaMa = table.Column<int>(type: "int", nullable: true),
                    TheLoaiMa = table.Column<int>(type: "int", nullable: true),
                    NhaXuatBanMa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saches", x => x.MaSach);
                    table.ForeignKey(
                        name: "FK_Saches_NhaXuatBans_NhaXuatBanMa",
                        column: x => x.NhaXuatBanMa,
                        principalTable: "NhaXuatBans",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saches_TacGias_TacGiaMa",
                        column: x => x.TacGiaMa,
                        principalTable: "TacGias",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saches_TheLoais_TheLoaiMa",
                        column: x => x.TheLoaiMa,
                        principalTable: "TheLoais",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocGias",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDocGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSinhVien = table.Column<int>(type: "int", nullable: false),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<int>(type: "int", nullable: false),
                    MaThe = table.Column<int>(type: "int", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheThuVienMa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocGias", x => x.Ma);
                    table.ForeignKey(
                        name: "FK_DocGias_TheThuViens_TheThuVienMa",
                        column: x => x.TheThuVienMa,
                        principalTable: "TheThuViens",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MuonTras",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThe = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheThuVienMa = table.Column<int>(type: "int", nullable: true),
                    NhanVienMa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuonTras", x => x.Ma);
                    table.ForeignKey(
                        name: "FK_MuonTras_NhanViens_NhanVienMa",
                        column: x => x.NhanVienMa,
                        principalTable: "NhanViens",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MuonTras_TheThuViens_TheThuVienMa",
                        column: x => x.TheThuVienMa,
                        principalTable: "TheThuViens",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMuonTras",
                columns: table => new
                {
                    MaMuonTra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSach = table.Column<int>(type: "int", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaTra = table.Column<bool>(type: "bit", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MuonTraMa = table.Column<int>(type: "int", nullable: true),
                    SachMaSach = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietMuonTras", x => x.MaMuonTra);
                    table.ForeignKey(
                        name: "FK_ChiTietMuonTras_MuonTras_MuonTraMa",
                        column: x => x.MuonTraMa,
                        principalTable: "MuonTras",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietMuonTras_Saches_SachMaSach",
                        column: x => x.SachMaSach,
                        principalTable: "Saches",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuonTras_MuonTraMa",
                table: "ChiTietMuonTras",
                column: "MuonTraMa");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuonTras_SachMaSach",
                table: "ChiTietMuonTras",
                column: "SachMaSach");

            migrationBuilder.CreateIndex(
                name: "IX_DocGias_TheThuVienMa",
                table: "DocGias",
                column: "TheThuVienMa");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTras_NhanVienMa",
                table: "MuonTras",
                column: "NhanVienMa");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTras_TheThuVienMa",
                table: "MuonTras",
                column: "TheThuVienMa");

            migrationBuilder.CreateIndex(
                name: "IX_Saches_NhaXuatBanMa",
                table: "Saches",
                column: "NhaXuatBanMa");

            migrationBuilder.CreateIndex(
                name: "IX_Saches_TacGiaMa",
                table: "Saches",
                column: "TacGiaMa");

            migrationBuilder.CreateIndex(
                name: "IX_Saches_TheLoaiMa",
                table: "Saches",
                column: "TheLoaiMa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietMuonTras");

            migrationBuilder.DropTable(
                name: "DocGias");

            migrationBuilder.DropTable(
                name: "MuonTras");

            migrationBuilder.DropTable(
                name: "Saches");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "TheThuViens");

            migrationBuilder.DropTable(
                name: "NhaXuatBans");

            migrationBuilder.DropTable(
                name: "TacGias");

            migrationBuilder.DropTable(
                name: "TheLoais");
        }
    }
}
