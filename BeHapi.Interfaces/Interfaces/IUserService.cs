using BeHapi.Models.Models;
using System;
using System.Threading.Tasks;

namespace BeHapi.Interfaces
{
    public interface IUserService
    {
       //Task FindUser(string username);
        UserOutputResponse LoginUser(string username, string password);
        UserOutputResponse RegisterUser(string username, string name, string email, string password);
    }


}
