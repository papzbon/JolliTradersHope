using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolliTradersHope.Shared.Models
{
    public readonly record struct LoggedInUser(Guid Id, string Name, string Role, string Username);
}
