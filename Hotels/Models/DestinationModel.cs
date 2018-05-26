namespace Hotels.Models
{
    public class DestinationModel
    {
        public string RegionId { get; set; }
        public string AssociatedMultiCityRegionId { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string TLA { get; set; }
        public string NonLocalizedCity { get; set; }
    }
}
