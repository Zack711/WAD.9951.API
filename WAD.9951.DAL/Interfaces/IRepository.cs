using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._9951.DAL.Interfaces
{
	public interface IRepository<T>
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		Task Add(T entity);
		Task Update(int id, T entity);
		Task Delete(int id);
	}
}
