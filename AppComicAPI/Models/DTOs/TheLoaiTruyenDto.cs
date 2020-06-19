using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class TheLoaiTruyenDto
    {
        public int MaTruyen { get; set; }
        public TruyenDto Truyen { get; set; }
        public int MaTheLoai { get; set; }
        public TheLoaiDto TheLoai { get; set; }
    }
}
