using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Sach
    {
        [Key]
        [Display(Name = "Mã sách")]
        [Required(ErrorMessage = "Bạn chưa nhập mã sách")]
        public string MaSach { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên sách")]
        [Display(Name = "Tên sách")]
        public string TenSach { get; set; }

        [Display(Name = "Tác giả")]
        public int MatacGia { get; set; }

        [Display(Name = "Thể loại")]
        public int MaTheLoai { get; set; }

        [Display(Name = "Nhà xuất bản")]
        public int MaNhaXuatBan { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập năm xuất bản")]
        [Display(Name = "Năm xuất bản")]
        public int NamXuatBan { get; set; }
        public TacGia TacGia { get; set; }
        public TheLoai TheLoai { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
        public ICollection<ChiTietMuonTra> ChiTietMuonTras { get; set; }
    }
}