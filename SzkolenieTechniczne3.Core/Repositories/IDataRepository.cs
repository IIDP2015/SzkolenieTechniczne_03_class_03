using System.Collections.Generic;
using SzkolenieTechniczne3.Core.Domain;

namespace SzkolenieTechniczne3.Core.Repositories
{
    public interface IDataRepository<T> where T : EntityBase
    {
        T Get(int id);
        IList<T> GetAll();
        int InsertOrUpdate(T item);
        void Remove(int id);
    }
}