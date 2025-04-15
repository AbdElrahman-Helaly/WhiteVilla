using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.Application.Common;
using Whitelagon.Infrastructure.Data;

namespace Whitelagon.Infrastructure.Repository
{
    public class Unitwork : Iunitofwork
    {
        private readonly ApplicationDbcontext db;
        public IVillaRepository Villa {get;private set;}
        public IAmenity Amenity { get; private set; }
        public IBooking Booking { get; private set; }
        public Unitwork(ApplicationDbcontext _Db)
        {
            db = _Db;
            Villa = new VillaRepository(db);
            Amenity = new AmenityRepository(db);
            Booking = new BookRepository(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
