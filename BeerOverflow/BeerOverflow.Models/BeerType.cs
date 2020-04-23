using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerOverflow.Models
{
    public class BeerType : IBeerType, IAudible, IDeletable
    {
        public BeerType()
        {
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength =3)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
