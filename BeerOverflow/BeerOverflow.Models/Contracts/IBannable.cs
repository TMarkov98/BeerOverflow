namespace BeerOverflow.Models.Contracts
{
    interface IBannable
    {
        bool IsBanned { get; set; }
        string BanReason { get; set; }
    }
}
