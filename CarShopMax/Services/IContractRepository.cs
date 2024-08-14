using CarShopMax.Model;

namespace CarShopMax.Services;

public interface IContractRepository
{

    public Task<Contract> IncrementStatusContract();

    public Task<Contract> SendChat(Chat chat);

}
