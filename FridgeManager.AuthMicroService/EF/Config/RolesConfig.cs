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
                Id = Guid.Parse("0f2e668f-9378-47a7-8aaf-831b46921073"),
                Name = RoleNames.User.ToString(),
                NormalizedName = RoleNames.User.ToString().ToUpper(),
            },
            new ApplicationRole()
            {
                Id = Guid.Parse("71efaeea-3b0b-49e4-a0fe-136bb7c1d29c"),
                Name = RoleNames.Admin.ToString(),
                NormalizedName = RoleNames.Admin.ToString().ToUpper(),
            },
            new ApplicationRole()
            {
                Id = Guid.Parse("eaebb81d-d857-4928-82a2-2528d9148aa4"),
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
