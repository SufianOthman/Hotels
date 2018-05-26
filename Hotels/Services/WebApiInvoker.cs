using Hotels.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Hotels.Services
{
    public class WebApiInvoker : IWebApiInvoker
    {
        const string Url = "https://offersvc.expedia.com/offers/v2/getOffers";

        public WebApiInvoker()
        {

        }
        public SearchResultsModel GetHotels(SearchCriteriaModel searchCriteria)
        {
            string baseUrl = Url;
            var uriBuilder = new UriBuilder(baseUrl);
            var query = CreateQueryFromCriteria(searchCriteria);

            uriBuilder.Query = query.ToString();

            dynamic resultObj = InvokeUrl(uriBuilder.Uri);

            var searchResults = JsonConvert.DeserializeObject<SearchResultsModel>(resultObj);

            return searchResults;
        }

        private string CreateQueryFromCriteria(SearchCriteriaModel searchCriteria)
        {
            var query = new StringBuilder();

            query.Append("scenario=deal-finder&page=foo&uid=foo&productType=Hotel");

            if (!string.IsNullOrEmpty(searchCriteria.DestinationName))
                query.AppendFormat("&destinationName={0}", searchCriteria.DestinationName);

            if (!string.IsNullOrEmpty(searchCriteria.DestinationCity))
                query.AppendFormat("&destinationCity={0}", searchCriteria.DestinationCity);

            if (!string.IsNullOrEmpty(searchCriteria.MinTripStartDate))
                query.AppendFormat("&minTripStartDate=:{0}", searchCriteria.MinTripStartDate);

            if (!string.IsNullOrEmpty(searchCriteria.MaxTripStartDate))
                query.AppendFormat("&maxTripStartDate=:{0}", searchCriteria.MaxTripStartDate);

            if (!string.IsNullOrEmpty(searchCriteria.MinStarRating))
                query.AppendFormat("&minStarRating={0}", searchCriteria.MinStarRating);

            if (!string.IsNullOrEmpty(searchCriteria.MaxStarRating))
                query.AppendFormat("&maxStarRating={0}", searchCriteria.MaxStarRating);

            if (!string.IsNullOrEmpty(searchCriteria.MinTotalRate))
                query.AppendFormat("&minTotalRate={0}", searchCriteria.MinTotalRate);

            if (!string.IsNullOrEmpty(searchCriteria.MaxTotalRate))
                query.AppendFormat("&maxTotalRate={0}", searchCriteria.MaxTotalRate);

            if (!string.IsNullOrEmpty(searchCriteria.MinGuestRating))
                query.AppendFormat("&minGuestRating={0}", searchCriteria.MinGuestRating);

            if (!string.IsNullOrEmpty(searchCriteria.MaxGuestRating))
                query.AppendFormat("&maxGuestRating={0}", searchCriteria.MaxGuestRating);

            if (!string.IsNullOrEmpty(searchCriteria.LengthOfStay))
                query.AppendFormat("&lengthOfStay={0}", searchCriteria.LengthOfStay);

            return query.ToString();
        }

        private dynamic InvokeUrl(Uri addressUrl)
        {
            var jsonString = string.Empty;

            using (WebClient client = new WebClient())
            {
                jsonString = client.DownloadString(addressUrl);
            }

            return jsonString;
        }

    }
}