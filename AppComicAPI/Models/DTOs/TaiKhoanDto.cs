using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Models.DTOs
{
    public class TaiKhoanDto
    {
        
        public int Id { get; set; }
       
        public string TenTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string TenHienThi { get; set; }

        public string Email { get; set; }
    }
}
