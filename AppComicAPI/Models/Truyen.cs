using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDocTruyenAPI.Models;

namespace AppComicAPI.Models
{
    public class Truyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string TenTruyen { get; set; }
        [Required]
        public DateTime NgayDang { get; set; }
        [Required]
        [ForeignKey("MaTaiKhoanDang")]
        public TaiKhoan TaiKhoan { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        public IList<TheLoai> TheLoais { get; set; }
    }
}
