using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public string Post000([FromBody] TaiKhoanDto taiKhoanDto)
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
                    return 0.ToString();
                }
                else
                {
                    return 1.ToString();
                }
            }

            return 2.ToString();
        }
    }
}