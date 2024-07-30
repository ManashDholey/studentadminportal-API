using Core.Entities;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Unit;
using Infrastructure.Services;
using studentadminportal_API.DataModels;
using studentadminportal_API.FileServices.Interface;
using studentadminportal_API.FileServices;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace studentadminportal_API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddDbContext<StudentAdminContext>(options =>
                           options.UseSqlServer(config.GetConnectionString("StudentAdminPortalDb")));
            services.Configure<AppSettings>(config.GetSection("AppSettings"));
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IImageRepository, LocalStorageImageRepository>();
            services.AddScoped<IClassServices, ClassServices>();
            services.AddScoped<IClassFeeServices, ClassFeeServices>();
            services.AddScoped<ITeachersServices, TeachersServices>();
            services.AddScoped<ITeachersAttendanceServices, TeachersAttendanceServices>();
            services.AddScoped<IStudentsAttendanceServices, StudentsAttendanceServices>();
            services.AddScoped<ITeachersSubjectServices, TeachersSubjectServices>();
            services.AddScoped<ISubjectsServices, SubjectsServices>();
            services.AddScoped<IExpenseServices, ExpenseServices>();
            
            services.AddSingleton<AppSettings>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
