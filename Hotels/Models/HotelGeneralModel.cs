using System.Collections.Generic;

namespace Hotels.Models
{
    public class HotelGeneralModel
    {
        public SearchCriteriaModel SearchCriteria { get; set; }
        public IEnumerable<HotelModel> HotelsList { get; set; }
    }
}
