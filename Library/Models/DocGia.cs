using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class DocGia
    {
        [Key]
        public int Ma { get; set; }

        [Required(ErrorMessage = "Bạn chua nhập tên độc giả")]
        [Display(Name = "Tên sinh viên")]
        public string TenDocGia { get; set; }

        [Required(ErrorMessage = "Bạn chua nhập số sinh viên")]
        [Display(Name = "Mã số sinh viên")]
        public int MaSinhVien { get; set; }
        [Display(Name = "Lớp")]
        public string Lop { get; set; }

        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public int SoDienThoai { get; set; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
    }
}