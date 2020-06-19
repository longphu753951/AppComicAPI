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
    public class PageController : ControllerBase
    {
        private IPageRepository _pRepo;
        private IMapper _mapper;

        public PageController(IPageRepository pRepo, IMapper mapper)
        {
            _pRepo = pRepo;
            _mapper = mapper;
        }
        [HttpGet("{MaChapter:int}")]
        public JsonResult GetPagesByChapter(int MaChapter)
        {
            var objList = _pRepo.GetPagesByChapter(MaChapter);
            var objDto = new List<PageDTOUpsert>();
            foreach (var obj in objList)
            {
                obj.Thumbnail = "http://10.0.2.2:45455" + obj.Thumbnail;
                objDto.Add(_mapper.Map<PageDTOUpsert>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpPost]
        public string ThemPage([FromBody] PageDTOUpsert pageDTO)
        {
            if (pageDTO == null)
            {
                return JsonConvert.SerializeObject("Mời nhập đầy đủ thông tin");
            }
            if (!ModelState.IsValid)
            {
                return "Lỗi";
            }
            var page = _mapper.Map<Page>(pageDTO);
            if (!_pRepo.CreatePage(page))
            {
                ModelState.AddModelError("", $"Không thể tạo page mới ");
                return JsonConvert.SerializeObject($"Không thể tạo page");
            }
            return JsonConvert.SerializeObject("Tạo thành công");
        }

    }
}