using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;
using Whitelagon.Infrastructure.Data;

namespace Whitelagon.Infrastructure.Repository
{
   public class BookRepository : Repository<Booking>, IBooking
    {
        public BookRepository(ApplicationDbcontext _Db) : base(_Db)
        {
        }
    }
    
    
}
