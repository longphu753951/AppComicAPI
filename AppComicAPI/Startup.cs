using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComicAPI.AppComicMaper;
using AppComicAPI.Models;
using AppComicAPI.Repository;
using AppComicAPI.Repository.IRepository;
using AppDocTruyenAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace AppDocTruyenAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.
                UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
            services.AddScoped<ITheLoaiTruyenRepository, TheLoaiTruyenRepository>();
            services.AddScoped<ITruyenRepository, TruyenRepository>();
            services.AddScoped<ITruyenYeuThichRepository, TruyenYeuThichRepository>();
            services.AddScoped<IChapterRepository,ChapterRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ITheLoaiRepository, TheLoaiRepository>();
            services.AddAutoMapper(typeof(AppComicMappings));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            app.Run(async (context) => { await context.Response.WriteAsync("Hello world"); } );

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting((state) =>
                {
                    if (context.Response.Headers.Count > 0 && context.Response.Headers.ContainsKey("Content-Type"))
                    {
                        var contentType = context.Response.Headers["Content-Type"].ToString();
                        if (contentType.StartsWith("application/json"))
                        {
                            context.Response.Headers.Remove("Content-Type");
                            context.Response.Headers.Append("Content-Type", "application/json");
                        }
                    }

                    return Task.FromResult(0);
                }, null);
                await next.Invoke();
            });

        }
    }
}
