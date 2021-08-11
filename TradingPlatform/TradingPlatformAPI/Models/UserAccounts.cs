using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            Trades = new HashSet<Trades>();
        }

        public int UserAccountId { get; set; }
        public int UserGroupId { get; set; }
        public int CounterpartyId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual UserGroups UserGroup { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
    }
}
