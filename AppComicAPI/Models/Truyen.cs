using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models;

namespace AppComicAPI.Models
{
    public class Truyen
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        
        [StringLength(200)]
        public string TenTruyen { get; set; }
        [Required]
        public DateTime NgayDang { get; set; }
        [Required]
        public int MaTaiKhoanDang { get; set; }
        [ForeignKey("MaTaiKhoanDang")]
        public TaiKhoan TaiKhoan { get; set; }
        [Required]
        
        [StringLength(300)]
        public string Thumbnail { get; set; }
        public int Like { get; set; }
        public IList<TheLoaiTruyen> TheLoaiTruyens { get; set; }
        public IList <TruyenYeuThich> TruyenYeuThichs { get; set; }
       
    }
}
