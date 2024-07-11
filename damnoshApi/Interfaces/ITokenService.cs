using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Models;

namespace damnoshApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AddUser user);
    }
}