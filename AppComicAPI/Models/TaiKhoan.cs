using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string TenTaiKhoan { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [Required]
        public string TenHienThi { get; set; }
        [Required]
        public string Email { get; set; }
        public IList<TruyenYeuThich> TruyenYeuThichs { get; set; }
    }
}
