using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class TruyenYeuThichDTO
    {
        public int MaTruyen { get; set; }
        public Truyen Truyen { get; set; }
        public int MaTaiKhoan { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
