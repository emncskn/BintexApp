//using Bintex.Data;
//using Bintex.Data.Entities.Account;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Bintex.WebApp
//{
//    public class Startup
//    {
//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services,IConfiguration config)
//        {
          
//            //config.getsection

//            services.AddControllersWithViews();
//            services.AddIdentity<BintexUser, BintexRole>().
//                AddEntityFrameworkStores<BintexContext>();
//            services.AddDbContext<BintexContext>(p =>
//            {
//                p.UseSqlServer("Data Source = DESKTOP-TJT2JL4; Initial Catalog=Bintex; User ID=euser;Password=123123");
//            });
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
               
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseAuthentication();
           
//            app.UseRouting();

//            app.UseAuthorization();
//            app.UseStaticFiles();
//            app.UseEndpoints(p => {
//                p.MapControllerRoute("Default",
//                    "{controller=Home}/{action=Index}");
              
//            });
//        }
//    }
//}
