using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDocTruyenAPI.Models;
using AppDocTruyenAPI.Models.DTOs;
using AutoMapper;

namespace AppComicAPI.AppComicMaper
{
    public class AppComicMappings:Profile
    {
        public AppComicMappings()
        {
            CreateMap<TaiKhoan, TaiKhoanDto>().ReverseMap();

        }
    }
}
