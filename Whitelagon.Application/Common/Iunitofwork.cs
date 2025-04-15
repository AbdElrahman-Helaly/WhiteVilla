using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelagon.Application.Common
{
    public interface Iunitofwork
    {
      public  IVillaRepository Villa { get; }
      public  IAmenity Amenity { get; }
      public  IBooking Booking { get; }
      public  void Save();
    }
}
