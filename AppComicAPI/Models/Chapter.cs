using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models
{
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        [StringLength(200)]
        public string TenChuong { get; set; }
        [Required]
        public DateTime NgayDang { get; set; }
        [Required]
        public int MaTruyen { get; set; }
        [ForeignKey("MaTruyen")]
        public Truyen Truyen { get; set; }
    }
}
