using System.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SICUENTANOS_Back.Models;

namespace SICUENTANOS_Back.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<bool> CreateAsync(T entity);    
        
        Task<bool> UpdateAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        

        private readonly ApplicationDbContext _context;


        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            try
            {
                var save = await _context.Set<T>().AddAsync(entity);

                if (save != null)                                  
                    created = true;  

                await  _context.SaveChangesAsync();              
            }
            catch (Exception)
            {
                throw;
            }                        
            return created;
        }

        public async Task<bool> UpdateAsync(Guid id)
        { 
            bool edited = false;
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return edited;
                } 

                var editEntity = _context.Set<T>().Update(entity);
                if (editEntity != null)
                    edited = true;
                
                await  _context.SaveChangesAsync();
            } 
            catch (Exception)
            {
                throw;
            }

            return edited;
        }

         public async Task<bool> DeleteAsync(Guid id)
        { 
            bool deleted = false;
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                    return deleted;
                

                var removeEntity = _context.Set<T>().Remove(entity);
                if (removeEntity != null)
                {
                    deleted = true;
                }
                await  _context.SaveChangesAsync();
            } 
            catch (Exception)
            {
                throw;
            }

            return deleted;
        }
    }
}