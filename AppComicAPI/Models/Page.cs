using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int MaChapter { get; set; }
        [ForeignKey("MaChapter")]
        public Chapter Chapter { get; set; }
        [Required]
        public string Thumbnail { get; set; }

    }
}
