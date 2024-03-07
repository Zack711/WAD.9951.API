using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WAD._9951.DAL.Data;
using WAD._9951.DAL.Interfaces;
using WAD._9951.DAL.Models;
using WAD._9951.DAL.Repositories;

namespace WAD._9951.DAL
{
	public static class DALConfigureServices
	{
		public static IServiceCollection DALConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			// Adding connection string to sql
			services.AddDbContext<FitnessAppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			// Depedency injection 
			services.AddScoped<IRepository<User>, UserRepository>();
			services.AddScoped<IRepository<FitnessActivity>, FitnessActivityRepository>();

			// Adding profile
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
