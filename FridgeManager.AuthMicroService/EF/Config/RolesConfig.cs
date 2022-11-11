using System;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.AuthMicroService.EF.Config
{
    public class RolesConfig : IEntityTypeConfiguration<ApplicationRole>
    {
        private static readonly ApplicationRole[] Roles =
        {
            new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.User.ToString(),
                NormalizedName = RoleNames.User.ToString().ToUpper(),
            },
            new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.Admin.ToString(),
                NormalizedName = RoleNames.Admin.ToString().ToUpper(),
            },
            new ApplicationRole()
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.Tester.ToString(),
                NormalizedName = RoleNames.Tester.ToString().ToUpper(),
            },
        };
           

        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(Roles);
        }
    }
}
