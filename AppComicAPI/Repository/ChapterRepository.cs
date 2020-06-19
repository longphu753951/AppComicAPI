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
    public class ChapterRepository : IChapterRepository
    {
        private readonly ApplicationDbContext _db;
        public ChapterRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateChapter(Chapter chapter)
        {
            _db.Chapters.Add(chapter);
            return Save();
        }

        public bool DeleteChapter(Chapter chapter)
        {
            _db.Chapters.Remove(chapter);
            return Save();
        }

        public Chapter GetChapterById(int id)
        {
            return _db.Chapters.FirstOrDefault(c => c.MaTruyen == id);
        }

        public ICollection<Chapter> GetChaptersByComic(int id)
        {
            return _db.Chapters.Include(c => c.Truyen).Where(c => c.MaTruyen == id).OrderByDescending(c=>c.Id).ToList();
        }

       
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateChapter(Chapter chapter)
        {
            _db.Chapters.Update(chapter);
            return Save();
        }

    }
}
