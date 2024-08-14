using AutoMapper;
using CarShopMax.Model.Open;
using CarShopMax.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShopMax.Controllers;

[Route("api/offers")]
[Authorize]
public class OffersController(IOfferRepository repo,
    IMapper mapper,
    IUserRepository userRepo) : Controller
{

    private IOfferRepository _repository = repo;
    private IUserRepository _userRepo = userRepo;
    private IMapper _mapper = mapper;

    [HttpGet()]
    public async Task<IActionResult> GetOffers([FromQuery(Name = "s")] string? search)
    {
        //var offers = await _repository.GetOffers(search);
        //var mkpfinal = _mapper.Map<Makeup>(mkp);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(int id)
    {
        // int.Parse(HttpContext.User.Claims.First(x => x.Type == "UserId").Value))
        await _repository.Delete(id);
        return Ok();
    }

    [HttpPost()]
    public async Task<IActionResult> CreateOffer([FromBody] Model.Offer makeup)
    {
        var mkp = _mapper.Map<Model.Offer>(makeup);
        mkp.UserId = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
        return Ok(_mapper.Map<Makeup>(await _repository.Save(mkp)));
    }

    [HttpPost("{id}/chats")]
    public async Task<IActionResult> PostChat([FromBody] Model.Chat makeup)
    {
        var mkp = _mapper.Map<Model.Offer>(makeup);
        mkp.UserId = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
        return Ok(_mapper.Map<Makeup>(await _repository.Save(mkp)));
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeOfferStatus([FromBody] Model.Chat makeup)
    {
        var mkp = _mapper.Map<Model.Offer>(makeup);
        mkp.UserId = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UserId").Value);
        return Ok(_mapper.Map<Makeup>(await _repository.Save(mkp)));
    }

}
