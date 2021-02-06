using System.Collections.Generic;

namespace Demo.Models
{
    public class Cart
    {
        public int UserId { get; set; } = 10;

        public List<CartLine> CartLines { get; set; } = new List<CartLine>()
        {
            new CartLine(){ProductName="لباس",Qunatity=10},
            new CartLine(){ProductName="شلوار",Qunatity=5},

        };
    }
}