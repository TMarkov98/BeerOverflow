using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string TargetBeer { get; set; }
        public string Author { get; set; }
    }
}
