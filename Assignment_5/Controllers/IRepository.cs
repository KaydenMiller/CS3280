using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    /// <summary>
    /// An interface for hooking up to a repository type system
    /// </summary>
    /// <typeparam name="KEY"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<KEY, T>
    {
        // Add CRUD operations methods
        // Create
        void Add(T value);
        // Read
        T GetValue(KEY key);
        IEnumerable<T> GetValues();
        // Update
        void UpdateValue(KEY key, T updatedValue);
        // Delete
        void Delete(KEY key);
    }
}
