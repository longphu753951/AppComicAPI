using AppComicAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface ITruyenRepository
    {
        public ICollection<Truyen> GetTruyens();
        public ICollection<Truyen> GetTopLikeTruyen();
        public ICollection<Truyen> GetNewTruyen();
        public ICollection<Truyen> GetTruyenByNguoiDang(int id);
        public Truyen GetTruyen(int truyenId);
        public ICollection<Truyen> GetTruyen(string tenTruyen);
        public bool TruyenExists(string name);
        public bool TruyenExists(int id);
        public bool CreateTruyen(Truyen truyen);
        public bool UpdateTruyen(Truyen truyen);
        public bool DeleteTruyen(Truyen truyen);
        bool Save();
    }
}
