using Hotels.Models;
using Hotels.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IWebApiInvoker _webApiInvoker;

        public HotelsController(IWebApiInvoker webApiInvoker)
        {
            _webApiInvoker = webApiInvoker;
        }



        [HttpGet]
        public ActionResult SearchHotel()
        {
            var hotelGeneralModel = new HotelGeneralModel();
            return View(hotelGeneralModel);
        }

        [HttpPost]
        public ActionResult SearchHotel(SearchCriteriaModel searchCriteria)
        {
            if (!ModelState.IsValid)
            {
                var hotelGeneralErrorModel = new HotelGeneralModel
                {
                    SearchCriteria = searchCriteria
                };
                return View(hotelGeneralErrorModel);
            }

            SearchResultsModel searchResultsModel = _webApiInvoker.GetHotels(searchCriteria);
            var hotelGeneralModel = new HotelGeneralModel
            {
                HotelsList = searchResultsModel.Offers.Hotel,
                SearchCriteria = searchCriteria
            };
            return View(hotelGeneralModel);
        }

    }
}