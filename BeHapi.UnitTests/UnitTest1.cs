using BeHapi.Controllers;
using BeHapi.Interfaces;
using BeHapi.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;


namespace BeHapi.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void SearchByName()
        {

            var mockInterfaceHotelSearchService = new Mock<IHotelSearchService>();

            HotelSearchController homeSearchcontroller = new HotelSearchController(mockInterfaceHotelSearchService.Object);
            HotelSearchResponse searchResponse = new HotelSearchResponse();
            searchResponse.Status = true;
            searchResponse.Message = string.Empty;

            List<Products> productResponse = new List<Products>();
            productResponse.Add(new Products
            {
                Id = 3190829,
                Name = "Verona Lodge by the Sea",
                Description = "Test5 Verona Lodge by the Sea, is a breakfast and self-catering holiday accommodation on the Cape Whale Coast,  situated in the pretty seaside town of Kleinmond.<br /><br />We have three comfortable guest rooms on a bed and breakfast basis, with access to the courtyard garden and guest lounge to relax in with tea and coffee facilities. Two adjoining rondavels are great for families with full self-catering facilities. Mineral water is also available to buy. <br /><br />A delicious breakfast is served in our sunny dining room, with plenty of advice on what to do for the day. Our B&B guest rooms are all en-suite with a bath and/or shower. We offer our guests hotel standard beds with comfortable T-Shirt bedding, towelling, hairdryers, ceiling fans and panel heaters, and plenty of cupboard space. The self-catering rooms are equipped the same as our B&B rooms, but share a bathroom.<br /><br />The house is a stones throw from the Main Beach and the start of the Coastal Walk. These include, walking one of the many hikes in the area, such as the Three Sisters or the Palmiet River Trail in the Kogelberg Biosphere Reserve.  Birding at the Rooisand Birdhide and Nature Reserve.",
                Latitude = "-34,34307727",
                Longitude = "19,03546729",
                Category = "Accommodation",
                PhysicalAddress = "6 1st Ave, Kleinmond, 7195, South Africa",
                LocationPath = "South Africa,Western Cape,Overberg,Whale Coast,Africa,World"
            });

            searchResponse.Data = productResponse;

            string hotelSearchByNameValue = "Verona Lodge by the Sea";

            mockInterfaceHotelSearchService.Setup(repo => repo.FindByName(hotelSearchByNameValue))
            .Returns(searchResponse);

            var result = homeSearchcontroller.SearchByName(hotelSearchByNameValue);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);

            Assert.ReferenceEquals(searchResponse, result);

        }
    }
}
