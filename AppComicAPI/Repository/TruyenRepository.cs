using AppComicAPI.Models;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository
{
    public class TruyenRepository : ITruyenRepository
    {
        private readonly ApplicationDbContext _db;
        public TruyenRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTruyen(Truyen truyen)
        {
            _db.Truyens.Add(truyen);
            return Save();
        }

        public bool DeleteTruyen(Truyen truyen)
        {
            _db.Truyens.Remove(truyen);
            return Save();
        }

        public ICollection<Truyen> GetNewTruyen()
        {
            return _db.Truyens.OrderByDescending(s => s.NgayDang.Date).Include(c => c.TaiKhoan).Take(9).ToList();
        }

        public ICollection<Truyen> GetTopLikeTruyen()
        {
             return _db.Truyens.OrderByDescending(s => s.Like).Include(c => c.TaiKhoan).Take(3).ToList();
            
        }

        public Truyen GetTruyen(int truyenId)
        {
            return _db.Truyens.FirstOrDefault(a => a.Id == truyenId);
        }

        public ICollection<Truyen> GetTruyen(string tenTruyen)
        {
            return _db.Truyens.Where(a => a.TenTruyen.Contains(tenTruyen)).ToList();
        }

        public ICollection<Truyen> GetTruyenByNguoiDang(int id)
        {
            return _db.Truyens.Include(c => c.TaiKhoan).Where(c => c.MaTaiKhoanDang == id).ToList();
        }

        public ICollection<Truyen> GetTruyens()
        {
            return _db.Truyens.OrderBy(a => a.TenTruyen).Include(c => c.TaiKhoan).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TruyenExists(string name)
        {
            return _db.Truyens.Any(a => a.TenTruyen.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TruyenExists(int id)
        {
            return _db.Truyens.Any(a => a.Id == id);
        }

        public bool UpdateTruyen(Truyen truyen)
        {
            _db.Truyens.Update(truyen);
            return Save();
        }
    }
}
