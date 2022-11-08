using System;
using FridgeManager.AuthMicroService.EF.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.AuthMicroService.EF.Config
{
    public class RolesConfig : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        private static readonly IdentityRole<Guid>[] Roles =
        {
            new IdentityRole<Guid>()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.User.ToString(),
                NormalizedName = RoleNames.User.ToString().ToUpper(),
            },
            new IdentityRole<Guid>()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.Admin.ToString(),
                NormalizedName = RoleNames.Admin.ToString().ToUpper(),
            },
            new IdentityRole<Guid>()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.Tester.ToString(),
                NormalizedName = RoleNames.Tester.ToString().ToUpper(),
            },
        };
           

        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(Roles);
        }
    }
}
