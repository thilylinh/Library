using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class MuonTra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Ma { get; set; }
        public int DocGiaMa { get; set; }
        public int NhanVienMa { get; set; }
        public DateTime NgayMuon { get; set; }
        public NhanVien NhanVien { get; set; }
        public DocGia DocGia { get; set; }
    }
}