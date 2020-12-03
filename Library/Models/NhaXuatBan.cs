using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class NhaXuatBan
    {
        [Key]
        public int Ma { get; set; }
        [Display(Name ="Tên nhà xuất bản")]
        [Required(ErrorMessage ="Bạn chưa nhập tên")]
        public string Ten { get; set; }
        [Display(Name = "Địa chỉ nhà xuất bản")]
        public string DiaChi { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email nhà xuất bản")]
        public string Email { get; set; }

        public ICollection<Sach> Saches { get; set; }
    }
}