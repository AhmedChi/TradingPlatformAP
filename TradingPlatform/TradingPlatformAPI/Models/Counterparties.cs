using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Counterparties
    {
        public Counterparties()
        {
            Addresses = new HashSet<Addresses>();
            CashAccounts = new HashSet<CashAccounts>();
            Equities = new HashSet<Equities>();
            InverseParentCounterparty = new HashSet<Counterparties>();
            SecuritiesAccountEquities = new HashSet<SecuritiesAccountEquities>();
            SecuritiesAccounts = new HashSet<SecuritiesAccounts>();
            Trades = new HashSet<Trades>();
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int CounterpartyId { get; set; }
        public int SectorId { get; set; }
        public int? ParentCounterpartyId { get; set; }
        public int CounterpartyAddressId { get; set; }
        public string CounterpartyName { get; set; }
        public string CounterpartyPhone { get; set; }
        public string CounterpartyEmail { get; set; }
        public string CounterpartyWebsite { get; set; }
        public bool IsOwnCompany { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties ParentCounterparty { get; set; }
        public virtual Sectors Sector { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<CashAccounts> CashAccounts { get; set; }
        public virtual ICollection<Equities> Equities { get; set; }
        public virtual ICollection<Counterparties> InverseParentCounterparty { get; set; }
        public virtual ICollection<SecuritiesAccountEquities> SecuritiesAccountEquities { get; set; }
        public virtual ICollection<SecuritiesAccounts> SecuritiesAccounts { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
        public virtual ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
