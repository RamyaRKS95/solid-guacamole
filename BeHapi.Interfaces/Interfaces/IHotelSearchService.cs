using BeHapi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Interfaces
{
    public interface IHotelSearchService
    {
        HotelSearchResponse FindByLocation(string location);
        HotelSearchResponse FindByName(string name);
    }
}
