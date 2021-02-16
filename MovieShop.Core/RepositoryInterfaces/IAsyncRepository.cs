using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace MovieShop.Core.RepositoryInterfaces
{
    // Generic constraints:<T> where: restrict T to a certain type (class, struct)
    // T = Movie
    public interface IAsyncRepository<T> where T:class
    {
        // CRUD: reading
        // R: Reading
        T GetByIdAsync(int id);
        IEnumerable<T> ListAllAsync();
        IEnumerable<T> ListAsync(Expression<Func<T, bool>> filter); //LinQ list of movies on some where condition where m.title="Avengere"
        int GetCountAsync(Expression<Func<T, bool>> filter=null); //default value is null
        bool GetExistsAsync(Expression<Func<T, bool>> filter=null);

        // C: Creating:
        T AddAsync(T entity);
        // U: Updating:
        T UpdatingAsync(T entity);
        // D: Deleting
        T DeleteAsync(T entity);

    }
}
