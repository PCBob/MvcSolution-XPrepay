﻿using System.Data.Entity.ModelConfiguration;
using Xprepay.Data;

namespace Xprepay.Data.Mappings
{
    public class UserRoleRLMapping : EntityTypeConfiguration<UserRoleRL>
    {
        public UserRoleRLMapping()
        {
            this.Require(x => x.User, x => x.UserRoleRLs, x => x.UserId);
            this.Require(x => x.Role, x => x.UserRoleRLs, x => x.RoleId);
        }
    }
}
