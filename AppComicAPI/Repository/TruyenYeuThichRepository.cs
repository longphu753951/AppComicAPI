using AppComicAPI.Models;
using AppComicAPI.Models.DTOs;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository
{
    public class TruyenYeuThichRepository : ITruyenYeuThichRepository
    {
        private readonly ApplicationDbContext _db;
        public TruyenYeuThichRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool DeleteTruyenYeuThich(int truyenId, int taiKhoanId)
        {
            var itemtoremove = _db.TruyenYeuThichs.Where(item => item.MaTruyen == truyenId && item.MaTaiKhoan == taiKhoanId).First();
            _db.TruyenYeuThichs.Remove(itemtoremove);
            return Save();
        }

        public IQueryable<Truyen> GetTruyenByTaiKhoan(int taiKhoanId)
        {
            return _db.TruyenYeuThichs.Where(c => c.MaTaiKhoan == taiKhoanId).Select(c => c.Truyen);
        }

        public bool InsertTruyenYeuThich(int truyenId, int taiKhoanId)
        {
            TruyenYeuThich a = new TruyenYeuThich();
            a.MaTaiKhoan = taiKhoanId;
            a.MaTruyen = truyenId;
            _db.TruyenYeuThichs.Add(a);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TruyenYeuThichExist(int truyenId, int taiKhoanId)
        {
            return _db.TruyenYeuThichs.Any(item => item.MaTaiKhoan == taiKhoanId && item.MaTruyen == truyenId);
        }
    }
}
