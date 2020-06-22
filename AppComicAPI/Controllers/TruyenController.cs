using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models;
using AppComicAPI.Models.DTOs;
using AppComicAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruyenController : ControllerBase
    {
        private ITruyenRepository _trRepo;
        private IMapper _mapper;

        public TruyenController(ITruyenRepository trRepo, IMapper mapper)
        {
            _trRepo = trRepo;
            _mapper = mapper;
        }
        [HttpGet("{MaTruyen:int}")]
        public ActionResult GetTruyen(int MaTruyen)
        {
            var obj = _trRepo.GetTruyen(MaTruyen);
            if(obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<TruyenDto>(obj);
            return Ok(objDto);
        }
        
        [HttpGet("Like")]
        
        public JsonResult GetLikeTruyen()
        {
            var objList = _trRepo.GetTopLikeTruyen();
            var objDto = new List<TruyenDtoUpsert>();
            foreach(var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200621175004.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDtoUpsert>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpGet("New")]

        public JsonResult GetNewTruyen()
        {
            var objList = _trRepo.GetNewTruyen();
            var objDto = new List<TruyenDtoUpsert>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200621175004.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDtoUpsert>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpPost("Search")]
        public JsonResult GetTruyen([FromBody] TruyenDtoUpsert truyen)
        {
            string tenTruyen = truyen.TenTruyen;
            var objList = _trRepo.GetTruyen(tenTruyen);
            var objDto = new List<TruyenDtoUpsert>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "https://appcomicapi20200621175004.azurewebsites.net" + obj.Thumbnail;
                objDto.Add(_mapper.Map<TruyenDtoUpsert>(obj));
            }
            return new JsonResult(objDto);
        }
    }
}