using System;
using System.Collections.Generic;

namespace Pizzeria.Core.Models
{
    public class Provider:BaseEntity
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Country { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}