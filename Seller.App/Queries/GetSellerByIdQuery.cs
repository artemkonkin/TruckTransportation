using System.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Seller.Domain.Entities;
using Shared.Context;

namespace Seller.App.Queries;

public class GetSellerByIdQuery : IRequest<SellerEntity>
{
    private Guid Id { get; set; }

    public GetSellerByIdQuery(Guid id)
    {
        Id = id;
    }

    public class GetSellerByIdQueryHandler : IRequestHandler<GetSellerByIdQuery,SellerEntity>
    {
        private readonly IApplicationDbContext _context;
        public GetSellerByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SellerEntity> Handle(GetSellerByIdQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Sellers.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken: cancellationToken);
            Debug.Assert(data != null, nameof(data) + " != null");
            return data;
        }
    }
}