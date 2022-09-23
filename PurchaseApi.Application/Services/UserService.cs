using PurchaseApi.Application.DTOs;
using PurchaseApi.Application.DTOs.Validations;
using PurchaseApi.Application.Services.Interface;
using PurchaseApi.Domain.Authentication;
using PurchaseApi.Domain.Repositories;

namespace PurchaseApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDto)
    {
        if (userDto == null) return ResultService.Fail<dynamic>("Objeto deve ser informado!");

        var validator = new UserDTOValidator().Validate(userDto);
        if (!validator.IsValid) return ResultService.RequestError<dynamic>("Problemas de validação!", validator);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDto.Email, userDto.Password);
        if (user == null) return ResultService.Fail<dynamic>("Usuário ou senha não encotrados");
        
        return ResultService.Ok(_tokenGenerator.Generator(user));
    }
}