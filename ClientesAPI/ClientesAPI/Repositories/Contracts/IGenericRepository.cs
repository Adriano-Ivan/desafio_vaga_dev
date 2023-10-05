namespace ClientesAPI.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid? id);
        Task<T> AddAsync(T entity);
    }
}
