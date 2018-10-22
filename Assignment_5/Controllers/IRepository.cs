using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
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
