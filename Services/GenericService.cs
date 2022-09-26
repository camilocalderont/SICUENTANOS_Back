using System.Linq.Expressions;
using SICUENTANOS_Back.Repository;
namespace SICUENTANOS_Back.Services
{
    public interface IGenericService<T> where T : class
    {
         Task<List<T>> GetAsync();

        Task<List<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");         

         void CreateAsync();

         Task<bool> UpdateAsync(Guid id,T entity);

         void DeleteAsync();

         bool ExistsAsync();
    }

    public class GenericService<T> : IGenericService<T> where T : class
    {
        public IGenericRepository<T> _genericRepository { get; }

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }        
        public void CreateAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAsync()
        {
            return await _genericRepository.GetAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            return await _genericRepository.GetAsync(whereCondition,orderBy,includeProperties);
        }           

        public async Task<bool> UpdateAsync(Guid id,T entity)
        {
            return await _genericRepository.UpdateAsync(id,entity);
        }

        public bool ExistsAsync()
        {
            return _genericRepository.ExistsAsync();
        }
    }    

}