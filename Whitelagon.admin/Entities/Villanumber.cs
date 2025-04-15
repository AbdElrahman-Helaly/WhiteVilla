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
    public class Villanumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Villa_Number { get; set; }
        [ForeignKey("Villa")]
        public int Villa_Id { get; set; }
        [ValidateNever]
        public Villa Villa { get; set; }
        public string? PublicDetails { get; set; }

    }
}
