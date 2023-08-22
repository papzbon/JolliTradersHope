using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolliTradersHope.Shared.Dtos
{
    public readonly record struct UserDto(Guid Id, string Name, bool IsActive);
    
}
