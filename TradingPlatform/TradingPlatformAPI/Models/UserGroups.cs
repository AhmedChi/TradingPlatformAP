using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class UserGroups
    {
        public UserGroups()
        {
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
