using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppComicAPI.Repository;
using AppComicAPI.Repository.IRepository;
using AppComicAPI.Models;
using AppComicAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public string Post([FromBody] TaiKhoanDto taiKhoanDto)
        {
            if (taiKhoanDto == null)
            {
                return JsonConvert.SerializeObject("Mời nhập đầy đủ thông tin");
            }

            if (_tkRepo.TaiKhoanExists(taiKhoanDto.TenTaiKhoan))
            {
                return JsonConvert.SerializeObject("Tên tài khoản đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return "Lỗi";
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
                ModelState.AddModelError("",$"Không thể tạo tài khoản ");
                return JsonConvert.SerializeObject($"Không thể tại tài khoản {taiKhoan.TenTaiKhoan}");
            }
            return JsonConvert.SerializeObject("Tạo thành công");
        }
    }
}