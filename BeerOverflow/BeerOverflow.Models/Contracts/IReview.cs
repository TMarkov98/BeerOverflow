namespace BeerOverflow.Models.Contracts
{
    public interface IReview
    {
        int Rating { get; set; }
        string Name { get; set; }
        string Text { get; set; }
        int TargetBeerId { get; set; }
        Beer TargetBeer { get; set; }
        int AuthorId { get; set; }
        User Author { get; set; }
    }
}
