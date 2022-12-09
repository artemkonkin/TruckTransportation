using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Seller.Domain.Dto;
using Seller.Domain.Entities;
using Shared.Context;

namespace Seller.App.Commands;

public class CreateSellerCommand : IRequest<Guid>
{
    private SellerDto Dto { get; set; }
    
    public CreateSellerCommand(SellerDto dto)
    {
        Dto = dto;
    }
    
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateSellerCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateSellerCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new SellerEntity
            {
                Id = default,
                Name = command.Dto.Name,
                BirthDate = command.Dto.BirthDate,
                PhoneNumber = command.Dto.PhoneNumber,
                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };

            _context.Sellers.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}