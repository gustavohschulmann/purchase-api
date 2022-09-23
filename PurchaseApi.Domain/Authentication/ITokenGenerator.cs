using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Domain.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(User user);
}