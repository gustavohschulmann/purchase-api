using PurchaseApi.Application.DTOs;

namespace PurchaseApi.Application.Services.Interface;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDto);
}