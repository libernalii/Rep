using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Update(int id,T item);
        Task Delete(T item);
        Task<T> GetById(int id);
        Task<T[]> GetAll();
    }
}
