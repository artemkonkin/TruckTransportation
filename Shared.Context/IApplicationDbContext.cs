using Microsoft.EntityFrameworkCore;
using Seller.Domain.Entities;

namespace Shared.Context;

public interface IApplicationDbContext
{
    DbSet<SellerEntity> Sellers { get; set; }
    
    Task<int> SaveChanges();
}