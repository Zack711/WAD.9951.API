using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._9951.DAL.Data;
using WAD._9951.DAL.Interfaces;
using WAD._9951.DAL.Models;

namespace WAD._9951.DAL.Repositories
{
	public class FitnessActivityRepository : IFitnessActivityRepository
	{
		private readonly FitnessAppDbContext _dbContext;

		public FitnessActivityRepository(FitnessAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<FitnessActivity>> GetAll()
		{
			return await _dbContext.FitnessActivities.ToListAsync();
		}

		public async Task<FitnessActivity> GetById(int id)
		{
			return await _dbContext.FitnessActivities.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task Add(FitnessActivity entity)
		{
			var user = await _dbContext.Users.FindAsync(entity.UserId);
			if (user == null)
			{
				// If the user with the specified ID does not exist, handle the error accordingly
				throw new InvalidOperationException($"User with ID {entity.UserId} does not exist.");
			}

			// Associate the user entity with the fitness activity
			entity.User = user;

			_dbContext.FitnessActivities.Add(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(int id, FitnessActivity entity)
		{
			var existingUser = await _dbContext.FitnessActivities.FindAsync(id);
			if (existingUser != null)
			{
				existingUser.UserId = entity.UserId;
				existingUser.DurationInMinutes = entity.DurationInMinutes;
				existingUser.ActivityType = entity.ActivityType;
				existingUser.Date = entity.Date;
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task Delete(int id)
		{
			var activity = await GetById(id);
			if (activity != null)
			{
				_dbContext.FitnessActivities.Remove(activity);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
