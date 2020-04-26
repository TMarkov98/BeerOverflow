namespace BeerOverflow.Services.DTO
{
    public interface IReviewDTO
    {
        string Author { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int Rating { get; set; }
        string TargetBeer { get; set; }
        string Text { get; set; }
    }
}