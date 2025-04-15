using Whitelagon.admin.Entities;

namespace whitelagon.Web.ViewModel
{
    public class HomeVM
    {
       public IEnumerable<Villa> VillaList { get; set; }
        public DateOnly CheckinDate { get; set; }
        public DateOnly CheckoutDate { get; set; }
        public int nights { get; set; }
    }
}
