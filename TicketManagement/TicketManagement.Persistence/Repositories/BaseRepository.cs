using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Contracts.Persistence;
using System.Linq;

namespace TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T: class
    {
        protected readonly TicketDbContext DbtContext;

        public BaseRepository(TicketDbContext dbContext)
        {
            DbtContext = dbContext;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbtContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbtContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbtContext.Set<T>().AddAsync(entity);
            await DbtContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            DbtContext.Entry(entity).State = EntityState.Modified;
            await DbtContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbtContext.Set<T>().Remove(entity);
            await DbtContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await DbtContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }
    }
}
