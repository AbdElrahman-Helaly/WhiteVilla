using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelagon.admin.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string? Description { get; set; }
        [Display(Name="Price per neigt")]
        public double  Price { get; set; }
        public int     Sqft { get; set; }
        public int     Occupancy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; } 
        public String? ImageUrl { get; set; }
        public DateTime?CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenities { get; set; }
        [NotMapped]
        public bool IsAvailable { get; set; } = true;


    }
}
