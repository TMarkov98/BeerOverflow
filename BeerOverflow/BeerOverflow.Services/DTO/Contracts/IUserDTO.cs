namespace BeerOverflow.Services.DTO
{
    public interface IUserDTO
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Role { get; set; }
        bool IsBanned { get; set; }
        string BanReason { get; set; }
    }
}