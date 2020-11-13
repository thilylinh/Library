using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class TheThuVien
    {
        [Key]
        public int Ma { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string GhiChu { get; set; }
    }
}