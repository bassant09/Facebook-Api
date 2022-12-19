using Facebook_Api.Data;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Facebook_Api.Services.Repository_Pattern
{
    public class RepositoryPattern<T> : IRepositoryPattern<T> where T : class
    {
        private readonly DataContext _db;
        public RepositoryPattern(DataContext db)
        {
            _db= db;    

        }
        public  async Task<ServicesRespone<IQueryable<T>>> Add(T entity)
        {
           await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            var data = _db.Set<T>().AsNoTracking();
            var respone = new ServicesRespone<IQueryable<T>>();
            respone.Data = data;
            return respone;

        }

        public  async Task<ServicesRespone<IQueryable<T>>> Delete(T entity)
        {
             _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            var data = _db.Set<T>().AsNoTracking();
            var respone = new ServicesRespone<IQueryable<T>>();
            respone.Data = data;
            return respone; 

        }

        public async Task<List<T>> GetAll()
        {
            var data = _db.Set<T>().ToList(); 
            return data;     
        }

        public Task<T> GetByCondtion(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
        
        public async Task<ServicesRespone<IQueryable<T>>> Update(T entity)
        {
            _db.Set<T>().Update(entity); 
            _db.SaveChanges();
            var respone = new ServicesRespone<IQueryable<T>>();
            var data = _db.Set<T>().AsNoTracking();
            respone.Data = data;
            return respone; 
        }
    }
}
