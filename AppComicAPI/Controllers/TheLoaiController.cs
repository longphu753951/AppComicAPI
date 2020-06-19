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
using Newtonsoft.Json;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private ITheLoaiRepository _tlRepo;
        private IMapper _mapper;

        public TheLoaiController(ITheLoaiRepository tkRepo, IMapper mapper)
        {
            _tlRepo = tkRepo;
            _mapper = mapper;
        }
        [HttpPost]
        public string Post([FromBody] TheLoaiDto theLoaiDto)
        {
            if (theLoaiDto == null)
            {
                return JsonConvert.SerializeObject("Mời nhập đầy đủ thông tin");
            }

            if (_tlRepo.TheLoaiExists(theLoaiDto.TenTheLoai))
            {
                return JsonConvert.SerializeObject("Tên thể loại đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return "Lỗi";
            }

            var theLoai = _mapper.Map<TheLoai>(theLoaiDto);
            
            if (!_tlRepo.CreateTheLoai(theLoai))
            {
                ModelState.AddModelError("", $"Không thể tạo thể loại ");
                return JsonConvert.SerializeObject($"Không thể tại thể loại {theLoai.TenTheLoai}");
            }

            return JsonConvert.SerializeObject("Tạo thành công");
        }
        [HttpGet]
        public JsonResult GetTheLoai()
        {

            var objList = _tlRepo.GetTheLoais();
            var objDto = new List<TheLoaiDto>();
            foreach (var obj in objList)
            {
                
                objDto.Add(_mapper.Map<TheLoaiDto>(obj));
            }
            return new JsonResult(objDto);
        }
    }
}