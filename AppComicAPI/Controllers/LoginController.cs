using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppComicAPI.Models;
using AppComicAPI.Repository.IRepository;
using AppComicAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace AppComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ITaiKhoanRepository _tkRepo;
        private IMapper _mapper;

        public LoginController(ITaiKhoanRepository tkRepo, IMapper mapper)
        {
            _tkRepo = tkRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post000([FromBody] TaiKhoanDto taiKhoanDto)
        {
            if (_tkRepo.TaiKhoanExists(taiKhoanDto.TenTaiKhoan))
            {
                var taiKhoan = _tkRepo.GetTaiKhoan(taiKhoanDto.TenTaiKhoan);
                string a = taiKhoanDto.MatKhau;
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(a);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
                a = new string("");
                foreach (byte item in hasData)
                {
                    a += item.ToString();
                }
                a.Reverse();
                if (taiKhoan.MatKhau.Equals(a))
                {
                    return Ok(taiKhoan);
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        [HttpPost("DoiThongTin")]
        public string DoiThongTin([FromBody] TaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = _mapper.Map<TaiKhoan>(taiKhoanDto);
            if (_tkRepo.TaiKhoanExists(taiKhoanDto.TenTaiKhoan))
            {
               
                    return JsonConvert.SerializeObject("Tên tài khoản đã tồn tại");
            }
            if (!_tkRepo.UpdateTaiKhoan(taiKhoan))
            {
                return JsonConvert.SerializeObject("Đổi thông tin thất bại");
            }
            return JsonConvert.SerializeObject("Đổi thông tin thành công");
        }
        [HttpPost("DoiMatKhau")]
        public string DoiMatKhau([FromBody] TaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = _mapper.Map<TaiKhoan>(taiKhoanDto);
            string a = taiKhoanDto.MatKhau;
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(a);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            a = new string("");
            foreach (byte item in hasData)
            {
                a += item.ToString();
            }

            a.Reverse();
            taiKhoan.MatKhau = a;
            if (!_tkRepo.UpdateTaiKhoan(taiKhoan))
            {
                return JsonConvert.SerializeObject("Đổi thông tin thất bại");
            }
            return JsonConvert.SerializeObject("Đổi thông tin thành công");
        }
       
    }
    
}