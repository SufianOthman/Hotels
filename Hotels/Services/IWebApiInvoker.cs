using Hotels.Models;

namespace Hotels.Services
{
    public interface IWebApiInvoker
    {
        SearchResultsModel GetHotels(SearchCriteriaModel searchCriteria);
    }
}