using CarShopMax.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarShopMax.Services.Generic;

public class OfferRepository(CarShopMaxContext cont) : IOfferRepository
{

    private readonly CarShopMaxContext _context = cont;
    //private readonly IValidator<Offer> _validator = validator;

    public async Task Delete(int id)
    {
        //await _context.Makeups.Where(x => x.Id == id).ExecuteDeleteAsync();
    }


    public async Task<IEnumerable<Offer>> GetByUser(int userId)
    {
        throw new Exception();
        //return await _context.Makeups.Include(x => x.Steps).Where(x => x.User.Id == userId).ToListAsync();
    }

    public async Task<Offer> GetNextByUser(int userId)
    {
        throw new Exception();
        //var makp = await _context.Makeups.Where(x => x.UserId != userId && !x.History.Any(y => y.UserId == userId)).Include(x => x.Steps).FirstOrDefaultAsync();
        //if (makp == null) return null;
        //_context.History.Add(new UserMakeupHistory() { UserId = userId, MakeupId = makp.Id });
        //await _context.SaveChangesAsync();
        //return makp;
    }

    public Task<IEnumerable<Offer>> GetOffers(int userId, string? filter)
    {
        throw new NotImplementedException();
    }

    public Task<bool> OfferBelongsToUser(int userId, int offerId)
    {
        throw new NotImplementedException();
    }

    public Task RejectActiveContract(int offerId, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Offer> Save(Offer makeup)
    {
        throw new Exception();
        //var currMakeup = await _context.Makeups.FirstOrDefaultAsync(x => x.Id == makeup.Id);
        //if (currMakeup == null)
        //{
        //    currMakeup = makeup;
        //    _context.Makeups.Add(currMakeup);
        //}
        //currMakeup.Name = makeup.Name;
        //currMakeup.Description = makeup.Description;
        //foreach (var item in makeup.Steps)
        //{
        //    var currStep = currMakeup.Steps.FirstOrDefault(x => x.Id == item.Id);
        //    if (currStep is null)
        //    {
        //        currMakeup.Steps.Add(item);
        //        continue;
        //    }
        //    currStep.Name = item.Name;
        //    currStep.Color = item.Color;
        //    currStep.Description = item.Description;
        //}
        //await _context.SaveChangesAsync();
        //return currMakeup;
    }

    public Task<Offer> SendChat(Chat chat)
    {
        throw new NotImplementedException();
    }

    public Task<Contract> StartContract(int offerId)
    {
        throw new NotImplementedException();
    }
}
