using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Unit;
using Infrastructure.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using studentadminportal_API;
using studentadminportal_API.DataModels;
using studentadminportal_API.Extensions;
using studentadminportal_API.FileServices;
using studentadminportal_API.FileServices.Interface;
using studentadminportal_API.Middleware;
using studentadminportal_API.Profile;

var builder = WebApplication.CreateBuilder(args);
var resourcePath = Path.Combine(builder.Environment.ContentRootPath, builder.Configuration.GetValue<string>("ResourcePath"));

// Ensure the directory exists
if (!Directory.Exists(resourcePath))
{
    Directory.CreateDirectory(resourcePath);
}
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(resourcePath));
//builder.Services.AddDataProtection()
//    .PersistKeysToFileSystem(new DirectoryInfo(@"h:\root\home\kumardholey-001\www\site1\keys"))
//    .SetApplicationName("kumardholey-001");
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = 443; // The default HTTPS port
//});
var corsSettings = builder.Configuration.GetSection("CorsSettings").Get<CorsSettings>();
builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins(corsSettings?.AllowedOrigins!)
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});
// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//    options.Secure = CookieSecurePolicy.Always;
//});
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentAdminPortal.API", Version = "v1" });
//});


var app = builder.Build();
app.UseCors("angularApplication");
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentAdminPortal.API v1"));
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Resources")),
    RequestPath = "/Resources"
});

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
