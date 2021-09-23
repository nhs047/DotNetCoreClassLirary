using System;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagement
{
    public class Program
    {
        public IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<EmployeeManagementDBContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                });
        }
    }
}
