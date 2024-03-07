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
	public class FitnessActivityRepository : IRepository<FitnessActivity>
	{
		private readonly FitnessAppDbContext _dbContext;

		public FitnessActivityRepository(FitnessAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<FitnessActivity> GetAll()
		{
			return _dbContext.FitnessActivities.ToList();
		}

		public FitnessActivity GetById(int id)
		{
			return _dbContext.FitnessActivities.FirstOrDefault(a => a.Id == id);
		}

		public void Add(FitnessActivity entity)
		{
			_dbContext.FitnessActivities.Add(entity);
			_dbContext.SaveChanges();
		}

		public void Update(FitnessActivity entity)
		{
			_dbContext.FitnessActivities.Update(entity);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var activity = GetById(id);
			if (activity != null)
			{
				_dbContext.FitnessActivities.Remove(activity);
				_dbContext.SaveChanges();
			}
		}
	}
}
