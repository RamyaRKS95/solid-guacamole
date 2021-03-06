using BeHapi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Interfaces.Interfaces
{
    public interface IHotelSearchServiceRepository
    {
        HotelSearchResponse GetDataByLocation(string location);
        HotelSearchResponse GetDataByName(string name);
    }
}
