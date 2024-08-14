using CarShopMax.Model;

namespace CarShopMax.Services;

public interface IOfferRepository
{

    public Task<Offer> Save(Offer offer);

    public Task<bool> OfferBelongsToUser(int userId, int offerId);

    public Task Delete(int id);

    public Task<IEnumerable<Offer>> GetOffers(int userId, string? filter);

    public Task RejectActiveContract(int offerId, int userId);

    public Task<Contract> StartContract(int offerId);

}
