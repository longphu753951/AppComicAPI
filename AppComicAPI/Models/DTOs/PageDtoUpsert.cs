using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class PageDTOUpsert
    {
        
        public int Id { get; set; }
        public int MaChapter { get; set; }
        public string Thumbnail { get; set; }
    }
}
