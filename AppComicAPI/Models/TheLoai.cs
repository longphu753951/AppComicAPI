using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class TheLoai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        
        [StringLength(300)]
        public string TenTheLoai { get; set; }
  
        [StringLength(500)]
        public string GhiChu { get; set; }

        public IList<TheLoaiTruyen> TheLoaiTruyens { get; set; }
    }
}
