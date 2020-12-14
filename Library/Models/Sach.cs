using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Sach
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Mã sách")]
        [Required(ErrorMessage = "Bạn chưa nhập mã sách")]
        public string MaSach { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên sách")]
        [Display(Name = "Tên sách")]
        public string TenSach { get; set; }

        [Display(Name = "Tác giả")]
        public string TacGia { get; set; }

        [Display(Name = "Thể loại")]
        public string TheLoai { get; set; }

        [Display(Name = "Nhà xuất bản")]
        public string NhaXuatBan { get; set; }

        [Display(Name = "Ngày nhập kho")]
        public DateTime NgayNhapKho { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập năm xuất bản")]
        [Display(Name = "Năm xuất bản")]
        public int NamXuatBan { get; set; }
        public string HinhAnh { get; set; }
        public ICollection<ChiTietMuonTra> ChiTietMuonTras { get; set; }
        public ICollection<Sach_Nganh> Sach_Nganhs { get; set; }
        public SachHong SachHong { get; set; }
    }
}