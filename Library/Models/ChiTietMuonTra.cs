using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ChiTietMuonTra
    {
        [Key]
        public int MaMuonTra { get; set; }
        public int MaSach { get; set; }
        public string Ghichu { get; set; }
        public bool DaTra { get; set; }
        public DateTime NgayTra { get; set; }
        public MuonTra MuonTra { get; set; }
        public Sach Sach { get; set; }
    }
}
