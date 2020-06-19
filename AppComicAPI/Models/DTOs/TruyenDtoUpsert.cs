using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models;

namespace AppComicAPI.Models.DTOs
{
    public class TruyenDtoUpsert
    {
        public int Id { get; set; }
        public string TenTruyen { get; set; }
        public DateTime NgayDang { get; set; }
        public int MaTaiKhoanDang { get; set; }
        
        public string Thumbnail { get; set; }

        public int Like { get; set; }

    }
}
