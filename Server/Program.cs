using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Server.Ctx.Models.Identity;
using Server.Data;
using Server.Extensions;
using Server.Seeds;
using Server.Utility;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog();

var _config = builder.Configuration;

builder.Services.AddSqlServer<PIPContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

//builder.Services.AddDbContext<PIPContext>(options =>
//                 options.UseSqlServer(
//            _config.GetConnectionString("DefaultConnection"))
//          );


// Add services to the container.
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
//ervices.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = false;
//    options.Events.OnRedirectToLogin = context =>
//    {
//        context.Response.StatusCode = 401;
//        return Task.CompletedTask;
//    };
//});
//builder.Services.AddControllers().AddNewtonsoftJson();
var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));


builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddApplicationLayer();
builder.Services.AddIdentityInfrastructure(_config);
builder.Services.AddPersistenceInfrastructure(_config);
builder.Services.AddSharedInfrastructure(_config);
builder.Services.AddSwaggerExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();
builder.Services.AddCurrentUserService();


//Read Configuration from appSettings
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var app = builder.Build();

//Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultSuperAdmin.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);
        Log.Information("Finished Seeding Default Data");
        Log.Information("Application Starting");
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "An error occurred seeding the DB");
    }
    finally
    {
        Log.CloseAndFlush();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
 .SetIsOriginAllowed(origin => true)
 .AllowAnyMethod()
 .AllowAnyHeader()
 .AllowCredentials());

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");
app.MapControllers();

app.Run();
