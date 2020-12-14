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
        [Display(Name = "Tên nhân viên quản lý")]
        public string Ten { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Số điện thoại")]
        public int SoDienThoai { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; } 
        public ICollection<MuonTra> MuonTras { get; set; }
    }
}
