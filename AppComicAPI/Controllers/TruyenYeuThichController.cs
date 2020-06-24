using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models.DTOs;
using AppComicAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruyenYeuThichController : ControllerBase
    {
        private ITruyenYeuThichRepository _tytRepo;
        private IMapper _mapper;

        public TruyenYeuThichController(ITruyenYeuThichRepository tytRepo, IMapper mapper)
        {
            _tytRepo = tytRepo;
            _mapper = mapper;
        }
        [HttpGet("KiemTra/{maTaiKhoan:int}/{maTruyen:int}")]
        public Boolean KiemTraTonTai(int maTruyen,int maTaiKhoan)
        {   
            if (!_tytRepo.TruyenYeuThichExist(maTruyen, maTaiKhoan))
            {
                return false;
            }
            return true;
        }
        [HttpPost("Them/{maTaiKhoan:int}/{maTruyen:int}")]
        public String ThemTruyenThich(int maTruyen, int maTaiKhoan)
        {
            if (_tytRepo.InsertTruyenYeuThich(maTruyen, maTaiKhoan))
            {
                return JsonConvert.SerializeObject("Đã thích truyện");
            }
            return JsonConvert.SerializeObject("Có lỗi"); ;
        }
        [HttpPost("Xoa/{maTaiKhoan:int}/{maTruyen:int}")]
        public String XoaTruyenThich(int maTruyen, int maTaiKhoan)
        {
            if (_tytRepo.DeleteTruyenYeuThich(maTruyen, maTaiKhoan))
            {
                return JsonConvert.SerializeObject("Dislike truyện thành công");
            }
            return JsonConvert.SerializeObject("Dislike truyện không thành công"); ;
        }
        [HttpGet("{MaTaiKhoan:int}")]
        public JsonResult GetTruyenByFavourite(int MaTaiKhoan)
        {
            var objList = _tytRepo.GetTruyenByTaiKhoan(MaTaiKhoan);
            var objDto = new List<TruyenDtoUpsert>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200624121436.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDtoUpsert>(obj));

            }
            return new JsonResult(objDto);
        }
    }
}