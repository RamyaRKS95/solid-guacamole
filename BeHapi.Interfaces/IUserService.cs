using System;
using System.Threading.Tasks;

namespace BeHapi.Interfaces
{
    public interface IUserService
    {
        Task FindUser(string username);
        Task LoginUser(string username, string password);
        Task RegisterUser(string username, string name, string email, string password);
    }

    public interface IHotelSearchService
    {
        Task FindByLocation(string location);
        Task FindByName(string name);
    }
}
