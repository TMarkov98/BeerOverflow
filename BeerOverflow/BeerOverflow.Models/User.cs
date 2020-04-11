using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class User : IUser, IDeletable, IAudible, IBannable
    {
        public int Id { get; set; }
        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.BeersDrank = new List<IBeer>();
            this.Wishlist = new List<IBeer>();
            this.Reviews = new List<IReview>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
        public ICollection<IBeer> BeersDrank { get; set; }
        public ICollection<IBeer> Wishlist { get; set; }
        public ICollection<IReview> Reviews { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
