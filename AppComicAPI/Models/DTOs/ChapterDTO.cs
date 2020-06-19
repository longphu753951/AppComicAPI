using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class ChapterDTO
    {
        
        public int Id { get; set; }
       
        public string TenChuong { get; set; }
        
        public DateTime NgayDang { get; set; }
        [Required]
        public int MaTruyen { get; set; }
        [ForeignKey("MaTruyen")]
        public TruyenDto Truyen { get; set; }
    }
}
