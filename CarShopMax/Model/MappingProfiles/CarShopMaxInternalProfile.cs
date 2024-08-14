using AutoMapper;

namespace CarShopMax.Model.MappingProfiles;

public class CarShopMaxInternalProfile : Profile
{

    /// <summary>
    /// Rila internal AutoMapper configuration
    /// </summary>
    public CarShopMaxInternalProfile()
    {

        CreateMap<Open.CredentialsDto, User>();
        CreateMap<Open.User, User>();
        //CreateMap<Open.MakeupStep, MakeupStep>();
        //CreateMap<MakeupStep, Open.MakeupStep>();
        CreateMap<Open.Makeup, Offer>();
        CreateMap<Offer, Open.Makeup>();

    }

}