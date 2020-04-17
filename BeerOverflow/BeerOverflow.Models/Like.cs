
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class Like
    {
        public Beer Beer { get; set; }
        public int BeerId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
