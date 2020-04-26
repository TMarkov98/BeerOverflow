using BeerOverflow.Services.DTO;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class ReviewViewModel
    {
        public ReviewViewModel()
        {

        }
        public ReviewViewModel(IReviewDTO reviewDTO)
        {
            this.Id = reviewDTO.Id;
            this.Name = reviewDTO.Name;
            this.Text = reviewDTO.Text;
            this.Rating = reviewDTO.Rating;
            this.TargetBeer = reviewDTO.TargetBeer;
            this.Author = reviewDTO.Author;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string TargetBeer { get; set; }
        public string Author { get; set; }
    }
}
