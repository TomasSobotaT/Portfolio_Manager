using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Managers;
using PortfolioManager.Api;
using PortfolioManager.Data;
using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Repositories;
using AutoMapper;
using Microsoft.OpenApi.Models;
//using static System.Net.WebRequestMethods;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using PortfolioManager.Managers;
using PortfolioManager.Interfaces;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(

    options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllers();
builder.Services.AddControllersWithViews();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("crypto", new OpenApiInfo
    {
        Version = "v1",
        Title = "Portfolio manager API",
        Description = "Webové API pro projekt Portfolio Manager vytvořené pomocí technologie ASP.NET CORE MVC.",
        Contact = new OpenApiContact
        {
            Name = "Kontakt",
            Url = new Uri("https://www.tsobota.cz")
        }
    });


    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);

});


builder.Services.AddScoped<IApiPriceManager, ApiPriceManager>();
builder.Services.AddScoped<IHistoricDataApiRepository, HistoricDataAPiRepository>();
builder.Services.AddScoped<IHistoricDataManager, HistoricDataManager>();
builder.Services.AddScoped<ICommodityRepository, CommodityRepository>();
builder.Services.AddScoped<IPortfolioCommodityManager, PortfolioCommodityManager>();
builder.Services.AddScoped<ICurrentPriceManager, CurrentPriceManager>();




builder.Services.AddAutoMapper(typeof(AutomapperConfigurationApi));
builder.Services.AddAutoMapper(typeof(AutomapperConfigurationMain));


var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en-US") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("en-US"),
	SupportedCultures = supportedCultures,
	SupportedUICultures = supportedCultures
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("crypto/swagger.json", "Portfolio Manager - v1");
    });
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();



app.Run();
