using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ChiTietMuonTra
    {
        [Key]
        public int ID { get; set; }
        public int MuonTraMa { get; set; }
        public string SachID { get; set; }
        public string Ghichu { get; set; }
        public bool DaTra { get; set; }
        public DateTime NgayTra { get; set; }
        public MuonTra MuonTra { get; set; }
        public Sach Sach { get; set; }
    }
}
