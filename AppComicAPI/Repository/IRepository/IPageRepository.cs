using AppComicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComicAPI.Repository.IRepository
{
    public interface IPageRepository
    {
        public ICollection<Page> GetPagesByChapter(int id);
        bool CreatePage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool Save();
    }
}
