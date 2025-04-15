using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.admin.Entities;

namespace Whitelagon.Application.Common
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeproperties = null);
        T Get(Expression<Func<T,bool>>? filter, string? includeproperties = null);
        public void Add(T Entity);
        public void Remove(T Entity);
       
    }
}
