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
    public class ChapterController : ControllerBase
    {
        private IChapterRepository _cRepo;
        private IMapper _mapper;

        public ChapterController(IChapterRepository cRepo, IMapper mapper)
        {
            _cRepo = cRepo;
            _mapper = mapper;
        }
        [HttpPost]
        public string ThemChapter([FromBody] ChapterDTO chapterDTO)
        {
            if (chapterDTO == null)
            {
                return JsonConvert.SerializeObject("Mời nhập đầy đủ thông tin");
            }
            if (!ModelState.IsValid)
            {
                return "Lỗi";
            }
            var chapter = _mapper.Map<Chapter>(chapterDTO);
            if (!_cRepo.CreateChapter(chapter))
            {
                ModelState.AddModelError("", $"Không thể tạo chapter mới ");
                return JsonConvert.SerializeObject($"Không thể tại chapter {chapter.TenChuong}");
            }
            return JsonConvert.SerializeObject("Tạo thành công");
        }
        [HttpGet("{MaTruyen:int}")]
        public JsonResult GetChapterByTruyen(int MaTruyen)
        {
            var objList = _cRepo.GetChaptersByComic(MaTruyen);
            var objDto = new List<ChapterDtoUpsert>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<ChapterDtoUpsert>(obj));
            }
            return new JsonResult(objDto);
        }
        [HttpDelete("{id:int}")]
        public string XoaChapter(int id)
        {
            if (id == 0)
            {
                return JsonConvert.SerializeObject("Mời nhập đầy đủ thông tin");
            }
            if (!ModelState.IsValid)
            {
                return "Lỗi";
            }
            Chapter chapter = _cRepo.GetChapterById(id);
            if (!_cRepo.DeleteChapter(chapter))
            {
                ModelState.AddModelError("", $"Không xóa chapter ");
                return JsonConvert.SerializeObject($"Không xóa chapter {chapter.TenChuong}");
            }
            return JsonConvert.SerializeObject("Xóa thành công");
        }
    }
}