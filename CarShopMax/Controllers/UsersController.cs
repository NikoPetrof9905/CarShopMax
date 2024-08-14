using AutoMapper;
using CarShopMax.Model;
using CarShopMax.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopMax.Controllers;

[Route("api/users")]
public class UsersController(IUserRepository repo,
    IMapper mapper) : Controller
{

    private IUserRepository _repository = repo;
    private IMapper _mapper = mapper;

    [HttpPost()]
    public async Task<IActionResult> Register([FromBody] Model.Open.CredentialsDto user)
    {
        return Ok(await _repository.SaveUserAsync(_mapper.Map<User>(user)));
    }

}
