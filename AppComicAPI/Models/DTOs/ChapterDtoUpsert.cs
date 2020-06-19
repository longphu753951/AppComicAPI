using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class ChapterDtoUpsert
    {
        public int Id { get; set; }
        public string TenChuong { get; set; }
        public DateTime NgayDang { get; set; }
        public int MaTruyen { get; set; }
       
    }
}
