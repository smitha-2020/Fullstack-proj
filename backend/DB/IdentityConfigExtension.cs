using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using backend.Models;

namespace backend.DB;


public static class IdentityConfigExtension
{
    public static void AddIdentityConfig(this ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("user");
        builder.Entity<IdentityRole<Guid>>().ToTable("roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
    }
}