using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaDeiGreciWebsite.Data.Menu
{
    public class Item : IOrderable, INamed
    {
        public Int32 Id { get; set; }
        public Int32 Order { get; set; }
        public Category Category { get; set; }
        public Int32 CategoryId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean Show { get; set; }
        public List<Price> Prices { get; } = new();
        public List<Quality> Qualities { get; } = new();
        public List<Allergen> Allergens { get; } = new();
        public List<ItemQuality> ItemQualities { get; } = new();
        public List<ItemAllergen> ItemAllergens { get; } = new();
    }
}
