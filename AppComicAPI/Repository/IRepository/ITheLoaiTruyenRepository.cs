using AppComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface ITheLoaiTruyenRepository
    {
        public IQueryable<TheLoai> GetTheLoaiByTruyen(int id);
        public IQueryable<Truyen> GetTruyenByTheLoai(int id);
        bool InsertTheLoaiTruyen(int theLoaiId, int truyenId);
        bool TheLoaiTruyenExists(int theLoaiId, int truyenId);
        public ICollection<Truyen> GetTruyenByTheLoais(int[] theLoaiId);
        bool DeleteTheLoaiTruyen(int theLoaiId, int truyenId);
        bool EditTheLoaiTruyen(int theLoaiId, int truyenId, int theLoaiMoiId);
        bool Save();
    }
}
