using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketQ.Data.Services
{
    public interface IDataAccess<T>
    {
        T Get(int id);
        void Add(T instance);
    }
}
