using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models;
using AppDocTruyenAPI.Models;
using System.Linq.Dynamic.Core;

namespace AppDocTruyenAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Truyen> Truyens { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
