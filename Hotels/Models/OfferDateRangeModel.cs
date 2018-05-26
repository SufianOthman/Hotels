using System.Collections.Generic;

namespace Hotels.Models
{
    public class OfferDateRangeModel
    {
       
        public IEnumerable<int> TravelStartDate { get; set; }

        public IEnumerable<int> TravelEndDate { get; set; }

        public int LengthOfStay { get; set; }
       
    }
}
