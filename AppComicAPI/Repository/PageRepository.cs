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
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDbContext _db;
        public PageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreatePage(Page page)
        {
            _db.Pages.Add(page);
            return Save();
        }

        public bool DeletePage(Page page)
        {
            _db.Pages.Remove(page);
            return Save();
        }

        public ICollection<Page> GetPagesByChapter(int id)
        {
            return _db.Pages.Where(c => c.MaChapter == id).OrderBy(a=>a.Id).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdatePage(Page page)
        {
            _db.Pages.Update(page);
            return Save();
        }
    }
}
