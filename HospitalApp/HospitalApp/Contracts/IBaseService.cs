using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IBaseService<T>
    {
        List<T> GetAll();

        T Add(T item);

        T DeleteById(int id);

        T UpdateById(int id, T item);
    }
}
