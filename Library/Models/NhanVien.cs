using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class NhanVien
    {
        [Key]
        public int Ma { get; set; }
        [Required(ErrorMessage = "Bạn chua nhập tên nhân viên")]
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public int SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; } 
        public ICollection<MuonTra> MuonTras { get; set; }
    }
}
