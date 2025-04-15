using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Whitelagon.admin.Entities;

namespace whitelagon.Web.ViewModel
{
    public class VillaNumberVm
    {
        public Villanumber Villanumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> List { get; set; }
    }
}
