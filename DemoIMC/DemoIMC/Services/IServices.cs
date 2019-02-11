using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoIMC.Services
{
    public interface IServices<T> where T: class, new()
    {

        Task<int> Insert(T obj);
        Task<int> Update(T obj);
        Task<int> Delete(T obj);
        Task<List<T>> GetAll();
        Task<List<T>> GetUserAndImc();
    }
}
