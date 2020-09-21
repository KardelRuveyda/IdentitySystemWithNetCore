using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentitySystemWithNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentitySystemWithNetCore
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            //services.AddMvcCore();
            //json çıktı almak istiyorum dersen AddMvcCore olabilir

            services.AddDbContext<AppIdentityDbContext>(opts =>
            {
                opts.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]);

            });

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();



        }

        // This method gets called  by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //Hata ile ilgili açıklayıcı bilgi sunar. 
            app.UseStatusCodePages();
            //Özellikle herhangi bir içerik dönmeyen sayfalarda bilgilendirici yazılar döner. 
            //Boş bir sayfa görmek yerine hatanın nerde olduğunu gösteren içerik döner. 
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();


            //arka planda Controller/Action/{id} route oluşturur. 

        }
    }
}
