using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class TacGia
    {
        [Key]
        public int Ma { get; set; }

        [Required(ErrorMessage = "Bạn chua nhập tên tác giả")]
        public string Ten { get; set; }

        public string GhiChu { get; set; }

        public ICollection<Sach> Saches { get; set; }
    }
}