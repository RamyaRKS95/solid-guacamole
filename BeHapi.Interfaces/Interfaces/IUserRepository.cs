using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Interfaces.Interfaces
{
    public interface IUserRepository
    {
        string InsertUserDetails(string username, string name, string email, string password);
        string ValidateUserAccess(string username, string password);
    }
}
