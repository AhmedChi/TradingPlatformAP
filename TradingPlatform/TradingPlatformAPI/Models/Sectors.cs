using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Sectors
    {
        public Sectors()
        {
            Counterparties = new HashSet<Counterparties>();
            Equities = new HashSet<Equities>();
        }

        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Counterparties> Counterparties { get; set; }
        public virtual ICollection<Equities> Equities { get; set; }
    }
}
