using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SachHong> SachHongs { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<Sach_Nganh> Sach_Nganhs { get; set; }
        public DbSet<NganhHoc> NganhHocs { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<MuonTra> MuonTras { get; set; }
        public DbSet<ChiTietMuonTra> ChiTietMuonTras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ChiTietMuonTra>(eb =>
                {
                    eb.HasKey(m => m.ID);
                });
            modelBuilder
                .Entity<Sach_Nganh>(eb =>
                {
                    eb.HasKey(o => new { o.NganhID, o.SachID });
                });
        }
    }
}