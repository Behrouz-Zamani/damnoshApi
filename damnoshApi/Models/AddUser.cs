using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace damnoshApi.Models
{
    public class AddUser:IdentityUser
    {
        // public int Risk { get; set; }

        public List<Portfolio> Portfolio {get;set;}=new List<Portfolio>();
    }
}