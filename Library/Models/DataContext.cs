using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ChiTietMuonTra> ChiTietMuonTras { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<MuonTra> MuonTras { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<TheThuVien> TheThuViens { get; set; }
    }
}
