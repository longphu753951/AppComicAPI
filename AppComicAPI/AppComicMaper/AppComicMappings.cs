using AppComicAPI.Models;
using AppComicAPI.Models.DTOs;
using AutoMapper;

namespace AppComicAPI.AppComicMaper
{
    public class AppComicMappings:Profile
    {
        public AppComicMappings()
        {
            CreateMap<TaiKhoan, TaiKhoanDto>().ReverseMap();
            CreateMap<TheLoai, TheLoaiDto>().ReverseMap();
            CreateMap<Truyen, TruyenDto>().ReverseMap();
            CreateMap<Truyen, TruyenDtoUpsert>().ReverseMap();
            CreateMap<Chapter, ChapterDTO>().ReverseMap();
            CreateMap<Chapter, ChapterDtoUpsert>().ReverseMap();
            CreateMap<TheLoaiTruyen, TheLoaiTruyenDto>().ReverseMap();
            CreateMap<Page, PageDTO>().ReverseMap();
            CreateMap<Page, PageDTOUpsert>().ReverseMap();
            CreateMap<TruyenYeuThich, TruyenYeuThichDTO>().ReverseMap();
            CreateMap<TaiKhoan, TaiKhoanDto>().ReverseMap();
            CreateMap<TaiKhoan, TaiKhoanDtoMK>().ReverseMap();
        }
    }
}
