using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class TheLoai
    {
        [Key]
        public int Ma { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên thể loại")]
        [Display(Name ="Tên thể loại")]
        public string TenTheLoai { get; set; }

        public ICollection<Sach> Saches { get; set; }
    }
}