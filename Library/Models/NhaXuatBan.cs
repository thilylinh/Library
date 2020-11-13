using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class NhaXuatBan
    {
        [Key]
        public int Ma { get; set; }
        [Required(ErrorMessage ="Bạn chưa nhập tên")]
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Sach> Saches { get; set; }
    }
}