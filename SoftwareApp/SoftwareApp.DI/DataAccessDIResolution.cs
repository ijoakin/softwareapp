using Microsoft.Extensions.DependencyInjection;
using SoftwareApp.BusinessLogic;
using SoftwareApp.DataAccess;
using SoftwareApp.DataAccess.Repository;
using SoftwareApp.Entities;
using SoftwareApp.IBusinessLogic;
using SoftwareApp.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareApp.DI
{
    public static class DataAccessDIResolution
    {
        public static void ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<SoftwareDBContext>(_ => new SoftwareDBContext(connectionString));
            services.AddTransient<ISoftwareBI, SoftwareBI>();
            services.AddTransient<IRepository<Software>, Repository<Software>>();
            services.AddTransient<IRepository<Platform>, Repository<Platform>>();
            services.AddTransient<IRepository<Location>, Repository<Location>>();
            services.AddTransient<IRepository<SoftwareType>, Repository<SoftwareType>>();

        }
    }
}
