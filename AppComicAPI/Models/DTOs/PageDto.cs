using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class PageDTO
    {
        
        public int Id { get; set; }
        [Required]
        public int MaChapter { get; set; }
        [ForeignKey("MaChapter")]
        public Chapter Chapter { get; set; }
        public string Thumbnail { get; set; }
    }
}
