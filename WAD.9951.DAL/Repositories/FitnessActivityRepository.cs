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
			_dbContext.FitnessActivities.Add(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(int id, FitnessActivity entity)
		{
			var existingEntry = _dbContext.FitnessActivities.FindAsync(id);
			if (existingEntry != null)
			{
				_dbContext.Entry(existingEntry).CurrentValues.SetValues(entity);
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
