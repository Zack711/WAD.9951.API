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
	public class UserRepository : IRepository<User>
	{
		private readonly FitnessAppDbContext _dbContext;

		public UserRepository(FitnessAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<User> GetAll()
		{
			return _dbContext.Users.ToList();
		}

		public User GetById(int id)
		{
			return _dbContext.Users.FirstOrDefault(u => u.Id == id);
		}

		public void Add(User entity)
		{
			_dbContext.Users.Add(entity);
			_dbContext.SaveChanges();
		}

		public void Update(User entity)
		{
			_dbContext.Users.Update(entity);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var user = GetById(id);
			if (user != null)
			{
				_dbContext.Users.Remove(user);
				_dbContext.SaveChanges();
			}
		}
	}
}
