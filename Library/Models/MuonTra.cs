using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class MuonTra
    {
        [Key]
        public int Ma { get; set; }

        public int MaThe { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayMuon { get; set; }
        public TheThuVien TheThuVien { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}