using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        [Required(ErrorMessage ="Bạn chua nhập tên sách")]
        public string TenSach { get; set; }
        public int MatacGia { get; set; }
        public int MaTheLoai { get; set; }
        public int MaNhaXuatBan { get; set; }
        [Required(ErrorMessage = "Bạn chua nhập năm xuất bản")]
        public int NamXuatBan { get; set; }

        public TacGia TacGia { get; set; }
        public TheLoai TheLoai { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
        public ICollection<ChiTietMuonTra> ChiTietMuonTras { get; set; }
    }
}
