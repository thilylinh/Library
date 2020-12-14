using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Sach_Nganh
    {
        [Key]
        [Column(Order = 1)]
        public int SachID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int NganhID { get; set; }
        public Sach Sach { get; set; }
        public NganhHoc Nganh { get; set; }
    }
}
