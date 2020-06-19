using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Repository;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Data;
using AppComicAPI.Models;

namespace AppComicAPI.Repository
{
    public class TaiKhoanRepository:ITaiKhoanRepository
    {
        private readonly ApplicationDbContext _db;

        public TaiKhoanRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<TaiKhoan> GetTaiKhoans()
        {
            return _db.TaiKhoans.OrderBy(a=>a.TenTaiKhoan).ToList();
        }

        public TaiKhoan GetTaiKhoan(int taiKhoanId)
        {
            return _db.TaiKhoans.FirstOrDefault(a => a.Id == taiKhoanId);
        }

        public TaiKhoan GetTaiKhoan(string tenTaiKhoan)
        {
            return _db.TaiKhoans.FirstOrDefault(a => a.TenTaiKhoan == tenTaiKhoan);
        }

        public bool TaiKhoanExists(string name)
        {
            return _db.TaiKhoans.Any(a => a.TenTaiKhoan.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TaiKhoanExists(int id)
        {
            return _db.TaiKhoans.Any(a => a.Id == id);
        }

        public bool CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            _db.TaiKhoans.Add(taiKhoan);
            return Save();
        }

        public bool UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            _db.TaiKhoans.Update(taiKhoan);
            return Save();
        }

        public bool DeleteTaiKhoan(TaiKhoan taiKhoan)
        {
            _db.TaiKhoans.Remove(taiKhoan);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
