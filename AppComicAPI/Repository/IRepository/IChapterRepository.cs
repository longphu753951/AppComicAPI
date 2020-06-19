using AppComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface IChapterRepository
    {

        public ICollection<Chapter> GetChaptersByComic(int id);
        Chapter GetChapterById(int id);
        bool CreateChapter(Chapter chapter);
        bool UpdateChapter(Chapter chapter);
        bool DeleteChapter(Chapter chapter);
        bool Save();
    }
}
