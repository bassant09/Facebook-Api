using Facebook_Api.Models;
using System.Linq.Expressions;

namespace Facebook_Api.Services.Repository_Pattern
{
    public interface IRepositoryPattern<T>
    {
        Task<List<T>> GetAll(); 
        Task<T>GetByCondtion(Expression<Func<T, bool>> expression);
        Task<ServicesRespone<IQueryable<T>>> Add(T entity);
        Task<ServicesRespone<IQueryable<T>>> Update(T entity);
        Task<ServicesRespone<IQueryable<T>>> Delete(T entity);

    }
}
