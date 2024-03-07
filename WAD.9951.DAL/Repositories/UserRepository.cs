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
	public class UserRepository : IUserRepository
	{
		private readonly FitnessAppDbContext _dbContext;

		public UserRepository(FitnessAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<User>> GetAll()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<User> GetById(int id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task Add(User entity)
		{
			_dbContext.Users.Add(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(int id, User entity)
		{
			var existingUser = _dbContext.Users.FindAsync(id);
			if (existingUser != null)
			{
				_dbContext.Entry(existingUser).CurrentValues.SetValues(entity);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task Delete(int id)
		{
			var user = await GetById(id);
			if (user != null)
			{
				_dbContext.Users.Remove(user);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
