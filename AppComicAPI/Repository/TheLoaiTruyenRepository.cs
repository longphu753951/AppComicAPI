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
    public class TheLoaiTruyenRepository : ITheLoaiTruyenRepository
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiTruyenRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool DeleteTheLoaiTruyen(int theLoaiId, int truyenId)
        {
            var itemtoremove = _db.TheLoaiTruyens.Where(item => item.MaTheLoai == theLoaiId && item.MaTruyen ==truyenId).First();
            _db.TheLoaiTruyens.Remove(itemtoremove);
            return Save();
        }

        public bool EditTheLoaiTruyen(int theLoaiId, int truyenId, int theLoaiMoiId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TheLoai> GetTheLoaiByTruyen(int id)
        {
            return _db.TheLoaiTruyens.Where(c => c.MaTruyen == id).Select(c=>c.TheLoai);
        }

        public IQueryable<Truyen> GetTruyenByTheLoai(int id)
        {
            return _db.TheLoaiTruyens.Where(c => c.MaTheLoai == id).Select(c => c.Truyen);
        }

        public ICollection<Truyen> GetTruyenByTheLoais(int[] theLoaiIds)
        {
            var query = _db.Truyens.AsQueryable();
            foreach (var theLoaiId in theLoaiIds)
            {

                var tempId = theLoaiId;
                query = query.Where(r => r.TheLoaiTruyens.Any(rc => rc.MaTheLoai == tempId));
            }
            return query.ToList();
        }

        public bool InsertTheLoaiTruyen(int theLoaiId, int truyenId)
        {
            TheLoaiTruyen a = new TheLoaiTruyen();
            a.MaTheLoai = theLoaiId; 
            a.MaTruyen = truyenId;
            _db.TheLoaiTruyens.Add(a);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TheLoaiTruyenExists(int theLoaiId, int truyenId)
        {
            return _db.TheLoaiTruyens.Any(item => item.MaTheLoai == theLoaiId && item.MaTruyen == truyenId);
        }
    }
}
