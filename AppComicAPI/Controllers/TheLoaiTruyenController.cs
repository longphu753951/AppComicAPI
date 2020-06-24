using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models.DTOs;
using AppComicAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiTruyenController : ControllerBase
    {
        private ITheLoaiTruyenRepository _tlrRepo;
        private IMapper _mapper;

        public TheLoaiTruyenController(ITheLoaiTruyenRepository tlrRepo, IMapper mapper)
        {
            _tlrRepo = tlrRepo;
            _mapper = mapper;
        }
        [HttpGet("Truyen/{MaTruyen:int}")]
        public JsonResult GetTheLoaiByTruyen(int MaTruyen)
        {
            var objList = _tlrRepo.GetTheLoaiByTruyen(MaTruyen);
            var objDto = new List<TheLoaiDto>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<TheLoaiDto>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpGet("TheLoai/{MaTruyen:int}")]
        public JsonResult GetTruyenByTheLoai(int MaTruyen)
        {
            var objList = _tlrRepo.GetTruyenByTheLoai(MaTruyen);
            var objDto = new List<TruyenDto>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200624121436.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDto>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpPost("Filter")]
        public JsonResult GetTruyenByTheLoaiFilter( List<int> theLoaiIds)
        {
           
            var objList = _tlrRepo.GetTruyenByTheLoais(theLoaiIds.ToArray());
            var objDto = new List<TruyenDto>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200624121436.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDto>(obj));
            }
            return new JsonResult(objDto);
        }
    }
}