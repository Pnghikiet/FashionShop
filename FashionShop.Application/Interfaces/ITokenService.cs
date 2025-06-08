using FashionShop.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user,IList<string> role);
    }
}
