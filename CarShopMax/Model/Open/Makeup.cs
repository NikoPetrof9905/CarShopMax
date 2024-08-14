namespace CarShopMax.Model.Open;

public class Makeup
{

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public IEnumerable<MakeupStep> Steps { get; set; }

    public User User { get; set; }

}
