using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocGias", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "NganhHocs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhHocs", x => x.ID);
                });

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
                name: "Saches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhaXuatBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayNhapKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NamXuatBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MuonTras",
                columns: table => new
                {
                    Ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocGiaMa = table.Column<int>(type: "int", nullable: false),
                    NhanVienMa = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuonTras", x => x.Ma);
                    table.ForeignKey(
                        name: "FK_MuonTras_DocGias_DocGiaMa",
                        column: x => x.DocGiaMa,
                        principalTable: "DocGias",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuonTras_NhanViens_NhanVienMa",
                        column: x => x.NhanVienMa,
                        principalTable: "NhanViens",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThongBao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienMa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongBaos_NhanViens_NhanVienMa",
                        column: x => x.NhanVienMa,
                        principalTable: "NhanViens",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach_Nganhs",
                columns: table => new
                {
                    SachID = table.Column<int>(type: "int", nullable: false),
                    NganhID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach_Nganhs", x => new { x.NganhID, x.SachID });
                    table.ForeignKey(
                        name: "FK_Sach_Nganhs_NganhHocs_NganhID",
                        column: x => x.NganhID,
                        principalTable: "NganhHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sach_Nganhs_Saches_SachID",
                        column: x => x.SachID,
                        principalTable: "Saches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SachHongs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SachID = table.Column<int>(type: "int", nullable: false),
                    SoLuongHong = table.Column<int>(type: "int", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBaoHong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SachHongs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SachHongs_Saches_SachID",
                        column: x => x.SachID,
                        principalTable: "Saches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMuonTras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuonTraMa = table.Column<int>(type: "int", nullable: false),
                    SachID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaTra = table.Column<bool>(type: "bit", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SachID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietMuonTras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietMuonTras_MuonTras_MuonTraMa",
                        column: x => x.MuonTraMa,
                        principalTable: "MuonTras",
                        principalColumn: "Ma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietMuonTras_Saches_SachID1",
                        column: x => x.SachID1,
                        principalTable: "Saches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuonTras_MuonTraMa",
                table: "ChiTietMuonTras",
                column: "MuonTraMa");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuonTras_SachID1",
                table: "ChiTietMuonTras",
                column: "SachID1");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTras_DocGiaMa",
                table: "MuonTras",
                column: "DocGiaMa");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTras_NhanVienMa",
                table: "MuonTras",
                column: "NhanVienMa");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_Nganhs_SachID",
                table: "Sach_Nganhs",
                column: "SachID");

            migrationBuilder.CreateIndex(
                name: "IX_SachHongs_SachID",
                table: "SachHongs",
                column: "SachID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_NhanVienMa",
                table: "ThongBaos",
                column: "NhanVienMa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietMuonTras");

            migrationBuilder.DropTable(
                name: "Sach_Nganhs");

            migrationBuilder.DropTable(
                name: "SachHongs");

            migrationBuilder.DropTable(
                name: "ThongBaos");

            migrationBuilder.DropTable(
                name: "MuonTras");

            migrationBuilder.DropTable(
                name: "NganhHocs");

            migrationBuilder.DropTable(
                name: "Saches");

            migrationBuilder.DropTable(
                name: "DocGias");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
