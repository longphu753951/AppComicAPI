using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class TruyenYeuThich
    {
        [Required]
        public int MaTruyen { get; set; }
        [ForeignKey("MaTruyen")]
        public Truyen Truyen { get; set; }
        [Required]
        public int MaTaiKhoan { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public TaiKhoan TaiKhoan { get; set; }
    }
}
