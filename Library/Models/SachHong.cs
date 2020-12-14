using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class SachHong
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SachID { get; set; }
        [Display(Name = "Số lượng hỏng")]
        public int SoLuongHong { get; set; }
        [Display(Name = "Lý do")]
        public string LyDo { get; set; }
        [Display(Name = "Ngày báo hỏng")]
        public DateTime NgayBaoHong { get; set; }
        public Sach Sach { get; set; }
    }
}
