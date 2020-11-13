using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class DocGia
    {
        [Key]
        public int Ma { get;set; }
        [Required(ErrorMessage = "Bạn chua nhập tên độc giả")]
        public string TenDocGia { get; set; }
        [Required(ErrorMessage = "Bạn chua nhập số sinh viên")]
        public int MaSinhVien { get; set; }
        public string Lop { get; set; }
        public string Email { get; set; }
        public int SoDienThoai { get; set; }
        public int MaThe { get; set; }
        public string MatKhau { get; set; }
        public TheThuVien TheThuVien { get; set; }
    }
}
