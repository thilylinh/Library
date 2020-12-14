using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ThongBao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name ="Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Ngày thông báo")]
        public DateTime NgayThongBao { get; set; }
        public int NhanVienMa { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
