using System.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Seller.Domain.Entities;
using Shared.Context;

namespace Seller.App.Queries;

public class GetSellersQuery : IRequest<SellerEntity>
{
    private Guid Id { get; set; }

    public GetSellersQuery(Guid id)
    {
        Id = id;
    }

    public class GetSellersQueryHandler : IRequestHandler<GetSellersQuery,SellerEntity>
    {
        private readonly IApplicationDbContext _context;
        public GetSellersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SellerEntity> Handle(GetSellersQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Sellers.FirstOrDefaultAsync(d => true, cancellationToken: cancellationToken);
            Debug.Assert(data != null, nameof(data) + " != null");
            return data;
        }
    }
}