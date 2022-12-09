using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seller.Domain.Entities;

namespace Shared.Context;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SellerEntity> Sellers { get; set; }

    public async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}