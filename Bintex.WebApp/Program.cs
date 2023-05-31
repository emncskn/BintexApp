using Bintex.Data.Entities.Account;
using Bintex.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Connection Operations
//conneciton String App
var context = builder.Configuration.GetConnectionString("BintexConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<BintexContext>(p =>
{
    p.UseSqlServer(context);
});
//Identityle sayfraya girerken hangi rol ve kullanýcý ile gireceiðimiz belli ediyor
builder.Services.AddIdentity<BintexUser, BintexRole>()
   // .AddUserManager<BintexUserManager>()
    .AddEntityFrameworkStores<BintexContext>();
//ayni entityden alýcaðýmýzý yazýyor
#endregion
//builder.Services.AddScoped<ISettingService, SiteSettings>();
//builder.Services.AddScoped<IEducationCategrofyService, EduCategoryService>();
//builder.Services.AddScoped<IEducation, EducationService>();
//builder.Services.AddTransient(typeof(IRepository<>), typeof(EntityRepository<>));
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
