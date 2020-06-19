using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class TheLoaiTruyen
    {
        [Required]
        public int MaTruyen { get; set; }
        [ForeignKey("MaTruyen")]
        public Truyen Truyen { get; set; }
        [Required]
        public int MaTheLoai { get; set; }
        [ForeignKey("MaTheLoai")]
        public TheLoai TheLoai { get; set; }
    }
}
