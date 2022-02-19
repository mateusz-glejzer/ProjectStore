using System;
using System.Collections.Generic;

namespace ProjectStore.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public List<ProductDto> basket = new ();
    }
}
