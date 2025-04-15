using Microsoft.AspNetCore.Mvc;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;

namespace whitelagon.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly Iunitofwork _unit;

        public BookingController(Iunitofwork unit)
        {
               _unit = unit;
                    
        }
        public IActionResult Finalizebooking(int villaId,DateOnly checkIndate,int neights)
        {
           Booking booking = new Booking()
            {
                VillaId = villaId,
                Villa = _unit.Villa.Get(u=>u.Id==villaId,includeproperties:"VillaAmenities"),
                CheckInDate = checkIndate,
                Nights = neights,
                CheckOutDate = checkIndate.AddDays(neights)
           };
            var villa = _unit.Villa.Get(u=>u.Id==villaId,null);
            if (villa != null)
            {
                booking.Villa = villa;
            }
            return View(booking);
        }
    }
}
