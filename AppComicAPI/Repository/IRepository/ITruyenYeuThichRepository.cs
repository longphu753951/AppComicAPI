using AppComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface ITruyenYeuThichRepository
    {
        public IQueryable<Truyen> GetTruyenByTaiKhoan(int taiKhoanId);
        bool InsertTruyenYeuThich(int truyenId, int taiKhoanId);
        bool TruyenYeuThichExist(int truyenId, int taiKhoanId);
        bool DeleteTruyenYeuThich(int truyenId, int taiKhoanId);
        bool Save();
    }
}
