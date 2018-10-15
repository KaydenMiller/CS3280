using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public interface IRepository<T>
    {
        // Add CRUD operations methods
        // Create
        void Add(T value);
        // Read
        T GetValue(int index);
        IEnumerable<T> GetValues();
        // Update
        void UpdateValue(int index, T updatedValue);
        // Delete
        void Delete(int index);
    }
}
