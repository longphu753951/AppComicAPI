using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.Models;
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
        public DbSet<TheLoaiTruyen> TheLoaiTruyens { get; set; }
        public DbSet<TruyenYeuThich> TruyenYeuThichs { get; set; }
        public DbSet<Chapter> Chapters { get; set; } 
        public DbSet<Page> Pages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Quan hệ nhiều nhiều giữa truyện và thể loại */
            modelBuilder.Entity<TheLoaiTruyen>().HasKey(tl => new { tl.MaTheLoai, tl.MaTruyen });
            modelBuilder.Entity<TheLoaiTruyen>()
                        .HasOne<Truyen>(sc => sc.Truyen)
                        .WithMany(s => s.TheLoaiTruyens)
                        .HasForeignKey(sc => sc.MaTruyen);


            modelBuilder.Entity<TheLoaiTruyen>()
                .HasOne<TheLoai>(sc => sc.TheLoai)
                .WithMany(s => s.TheLoaiTruyens)
                .HasForeignKey(sc => sc.MaTheLoai);
            /*Quan hệ nhiều nhiều giữa truyện và người thích truyện */

            modelBuilder.Entity<TruyenYeuThich>().HasKey(ty => new { ty.MaTaiKhoan, ty.MaTruyen });
            modelBuilder.Entity<TruyenYeuThich>()
                        .HasOne<Truyen>(s => s.Truyen)
                        .WithMany(s => s.TruyenYeuThichs)
                        .HasForeignKey(sc => sc.MaTruyen)
                        .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<TruyenYeuThich>()
                .HasOne<TaiKhoan>(sc => sc.TaiKhoan)
                .WithMany(s => s.TruyenYeuThichs)
                .HasForeignKey(sc => sc.MaTaiKhoan)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
