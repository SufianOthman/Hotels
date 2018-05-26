namespace Hotels.Models
{
    public class HotelPricingInfoModel
    {
        public double AveragePriceValue { get; set; }
        public double TotalPriceValue { get; set; }
        public double CrossOutPriceValue { get; set; }
        public double OriginalPricePerNight { get; set; }
        public string Currency { get; set; }
        public double PercentSavings { get; set; }     
        public bool DRR { get; set; }
    }
}
