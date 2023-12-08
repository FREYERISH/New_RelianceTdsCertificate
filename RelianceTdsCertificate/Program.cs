
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RelianceTdsCertificate.DataAccess;
using RelianceTdsCertificate.DataAccess.IRepository;
using RelianceTdsCertificate.DataAccess.Repository;
using RelianceTdsCertificate.Models;
using RelianceTdsCertificate.Service;
using RelianceTdsCertificate.Service.IService;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuring the ApplicationDbContext Dependency

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbLoginCredentials")));

//Configuring the Verification Data Access Service
builder.Services.AddScoped<IVerification<Employee>,Verification>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbLoginCredentials")));

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MailService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
