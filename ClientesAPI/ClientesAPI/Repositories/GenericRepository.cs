using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ClientesAPIContext clientesAPIContext;

        public GenericRepository(ClientesAPIContext clientesAPIContext)
        {
            this.clientesAPIContext = clientesAPIContext;   
        }

        public async Task<T> AddAsync(T entity)
        {
            await clientesAPIContext.AddAsync(entity);

            await clientesAPIContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await clientesAPIContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Guid? id)
        {
            if (id == null) return null;

            return await clientesAPIContext.Set<T>().FindAsync(id);
        }
    }
}
