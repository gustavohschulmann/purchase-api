using PurchaseApi.Infra.Data.Repositories;

namespace PurchaseApi.Domain.FiltersDb;

public class PersonFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}