using Shared.Core.Entities;

namespace Seller.Domain.Entities;

public class SellerEntity : BaseEntity
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
}