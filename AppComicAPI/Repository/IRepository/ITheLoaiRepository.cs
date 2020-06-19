using AppComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface ITheLoaiRepository
    {

        public ICollection<TheLoai> GetTheLoais();
        TheLoai GetTheLoai(int theLoaiId);
        TheLoai GetTheLoai(string tenTheLoai);
        bool TheLoaiExists(string name);
        bool TheLoaiExists(int id);
        bool CreateTheLoai(TheLoai theLoai);
        bool UpdateTheLoai(TheLoai theLoai);
        bool DeleteTheLoai(TheLoai theLoai);
        bool Save();
    }
}
