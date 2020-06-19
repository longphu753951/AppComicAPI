using AppComicAPI.Models;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository
{
    public class TheLoaiRepository : ITheLoaiRepository
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTheLoai(TheLoai theLoai)
        {
            _db.TheLoais.Add(theLoai);
            return Save();
        }

        public bool DeleteTheLoai(TheLoai theLoai)
        {
            _db.TheLoais.Remove(theLoai);
            return Save();
        }

        public TheLoai GetTheLoai(int theLoaiId)
        {
            return _db.TheLoais.FirstOrDefault(a =>a.Id==theLoaiId);
        }

        public TheLoai GetTheLoai(string tenTheLoai)
        {
            return _db.TheLoais.FirstOrDefault(a => a.TenTheLoai== tenTheLoai);
        }

        public ICollection<TheLoai> GetTheLoais()
        {
            return _db.TheLoais.OrderBy(a => a.TenTheLoai).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TheLoaiExists(string name)
        {
            return _db.TheLoais.Any(a => a.TenTheLoai.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TheLoaiExists(int id)
        {
            return _db.TheLoais.Any(a => a.Id == id);
        }

        public bool UpdateTheLoai(TheLoai theLoai)
        {
            _db.TheLoais.Update(theLoai);
            return Save();
        }
    }
}
