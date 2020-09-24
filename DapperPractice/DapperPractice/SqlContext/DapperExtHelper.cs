using Dapper.Contrib.Extensions;
using DapperPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPractice.SqlContext
{
    public class DapperExtHelper<T> where T:BaseEntity
    {
        public T Get(int id)
        {
            return ConnectionOption.DbConnection.Get<T>(id);
        }
        public IEnumerable<T> GetAll(int id)
        {
            return ConnectionOption.DbConnection.GetAll<T>();
        }
        public long Insert(T t)
        {
            return ConnectionOption.DbConnection.Insert(t);
        }
        public bool Update(T t)
        {
            return ConnectionOption.DbConnection.Update(t);
        }
        public bool Delete(T t)
        {
            return ConnectionOption.DbConnection.Delete(t);
        }
        public bool DeleteAll(int id)
        {
            return ConnectionOption.DbConnection.DeleteAll<T>();
        }
    }
}
