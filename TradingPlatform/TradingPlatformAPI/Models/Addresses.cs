using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Addresses
    {
        public int AddressId { get; set; }
        public int? CounterpartyId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
    }
}
