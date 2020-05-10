using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using AppDocTruyenAPI.Models;

namespace AppComicAPI.Repository.IRepository
{
    public interface ITaiKhoanRepository
    {
        public ICollection<TaiKhoan> GetTaiKhoans();
        TaiKhoan GetTaiKhoan(int taiKhoanId);
        TaiKhoan GetTaiKhoan(string tenTaiKhoan);
        bool TaiKhoanExists(string name);
        bool TaiKhoanExists(int id);
        bool CreateTaiKhoan(TaiKhoan taiKhoan);
        bool UpdateTaiKhoan(TaiKhoan taiKhoan);
        bool DeleteTaiKhoan(TaiKhoan taiKhoan);
        bool Save();

    }
}
