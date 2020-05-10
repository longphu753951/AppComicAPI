using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppComicAPI.Repository;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Models;
using AppDocTruyenAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private ITaiKhoanRepository _tkRepo;
        private IMapper _mapper;

        public RegisterController(ITaiKhoanRepository tkRepo, IMapper mapper)
        {
            _tkRepo = tkRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaiKhoanDto taiKhoanDto)
        {
            if (taiKhoanDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_tkRepo.TaiKhoanExists(taiKhoanDto.TenTaiKhoan))
            {
                ModelState.AddModelError("","Tên tài khoản đã tồn tại");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taiKhoan = _mapper.Map<TaiKhoan>(taiKhoanDto);
            string a = taiKhoan.MatKhau;
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(a);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            a = new string("");
            foreach (byte item in hasData)
            {
                a += item.ToString();
            }
            a.Reverse();
            taiKhoan.MatKhau = a;
            if (!_tkRepo.CreateTaiKhoan(taiKhoan))
            {
                ModelState.AddModelError("",$"Không thể tạo tài khoản {taiKhoan.TenTaiKhoan}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}