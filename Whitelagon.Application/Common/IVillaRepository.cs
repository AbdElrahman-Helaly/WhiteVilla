using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.admin.Entities;

namespace Whitelagon.Application.Common
{
        public interface IVillaRepository : IRepository<Villa>
    {
        public void Update(Villa Entity);
        public void Save();
    }
}
