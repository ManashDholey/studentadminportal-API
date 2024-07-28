using Core.Entities.Identity;
using Core.Interfaces.Services;
using Core.Interfaces;
using Infrastructure.Data.Identity;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using studentadminportal_API.DataModels;
using System.Text;

namespace studentadminportal_API.Extensions
{
    public static class IdentityServiceEvtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services
       , IConfiguration config)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddDbContext<AppIdentityDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("StudentAdminPortalDb")));
           
            services.AddIdentityCore<AppUser>(options => {
                // Password settings
                // options.Password.RequireDigit = true;
                // options.Password.RequiredLength = 8;
                // options.Password.RequireNonAlphanumeric = true;
                // options.Password.RequireUppercase = true;
                // options.Password.RequireLowercase = true;

                // // Lockout settings
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                // options.Lockout.MaxFailedAccessAttempts = 5;
                // options.Lockout.AllowedForNewUsers = true;

                // // User settings
                // options.User.RequireUniqueEmail = true;

                // // Sign in settings
                // options.SignIn.RequireConfirmedEmail = true;
                // options.SignIn.RequireConfirmedAccount = false;
                //builder.Services.AddAuthentication(x =>
                //{
                //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                //})

            }).AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Secret"])),
                    //IssuerSigningKey = Encoding.ASCII.GetBytes(config["Token:Key"]),
                    //ValidIssuer = config["Token:Issuer"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    SaveSigninToken = true,

                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
