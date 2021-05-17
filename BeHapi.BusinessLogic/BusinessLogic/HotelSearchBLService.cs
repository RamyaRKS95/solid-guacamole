using BeHapi.Interfaces;
using BeHapi.Interfaces.Interfaces;
using BeHapi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.BusinessLogic.BusinessLogic
{
    public class HotelSearchBLService : IHotelSearchService
    {

        //Dependency Injection
        private readonly IHotelSearchServiceRepository _hotelSearchRepositoryService;
        public HotelSearchBLService(IHotelSearchServiceRepository hotelSearchRepositoryService)
        {
            _hotelSearchRepositoryService = hotelSearchRepositoryService;
        }

        public HotelSearchResponse FindByLocation(string location)
        {
            HotelSearchResponse output = new HotelSearchResponse();
            string message = string.Empty;
            try
            {
                output = _hotelSearchRepositoryService.GetDataByLocation(location);

                if (output.Status && output.Data.Count == 0)
                    output.Message = "No Data Found for Search Hotel Location : " + location;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Message = ex.Message;

            }
            return output;
        }

        public HotelSearchResponse FindByName(string name)
        {
            HotelSearchResponse output = new HotelSearchResponse();
            string message = string.Empty;
            try
            {
                output = _hotelSearchRepositoryService.GetDataByName(name);

                if (output.Status && output.Data.Count == 0)
                    output.Message = "No Data Found for Search Hotel Name : " + name;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Message = ex.Message;

            }
            return output;
        }
    }
}
