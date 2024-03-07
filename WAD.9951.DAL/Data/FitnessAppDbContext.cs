using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._9951.DAL.Models;

namespace WAD._9951.DAL.Data
{
	public class FitnessAppDbContext : DbContext
	{
		public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<FitnessActivity> FitnessActivities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure entity relationships, constraints, etc.
			modelBuilder.Entity<FitnessActivity>()
				.HasOne(e => e.User)
				.WithMany(e => e.FitnessActivities)
				.HasForeignKey(e => e.Id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
