namespace UpSoluctions.API.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> SearchByIdAsync(params object[] keys);
        Task<T> GetByIdAsync(params object[] keys);
        Task<ICollection<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, params object[] keys);
        Task<T> DeleteAsync(params object[] keys);
    }
}
