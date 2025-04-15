using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelagon.admin.Entities
{
    public class AppIdentitiy : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    
    }
}
