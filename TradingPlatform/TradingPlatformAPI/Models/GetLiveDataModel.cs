namespace TradingPlatformAPI.Models
{
    public class GetLiveDataModel
    {
        public GlobalQuote GlobalQuote { get; set; }
    }

    public class GlobalQuote
    {
        public string _01symbol { get; set; }
        public string _02open { get; set; }
        public string _03high { get; set; }
        public string _04low { get; set; }
        public string _05price { get; set; }
        public string _06volume { get; set; }
        public string _07latesttradingday { get; set; }
        public string _08previousclose { get; set; }
        public string _09change { get; set; }
        public string _10changepercent { get; set; }
    }
}


  