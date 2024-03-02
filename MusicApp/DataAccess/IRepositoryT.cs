using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.DataAccess
{
    /// <summary>
    /// A base repository class for interactions with the database
    /// </summary>
    /// <typeparam name="Key">The key type</typeparam>
    /// <typeparam name="T">The data model or object</typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Saves all database changes made to the backing store
        /// </summary>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <returns></returns>
        Task<DbTransactionInfo> SaveChangesAsync();

        /// <summary>
        /// Saves all database changes made to the backing store
        /// </summary>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <returns></returns>
        DbTransactionInfo SaveChanges();

        void Insert(T model);

        Task InsertAsync(T model);

        Task InsertOrUpdate(T model);

        void InsertRange(IEnumerable<T> model);

        Task InsertRangeAsync(IEnumerable<T> model);

        void Delete(T entity);

        Task DeleteAsync(long key);

        Task DeleteAsync(Func<T, bool> expression);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T model);
    }
}