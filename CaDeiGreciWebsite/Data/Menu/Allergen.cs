using System;
using System.Collections.Generic;

namespace CaDeiGreciWebsite.Data.Menu
{
    public class Allergen : IOrderable, INamed
    {
        public Int32 Id { get; set; }
        public Int32 Order { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime ImageUpdateDate { get; set; }
        public List<Item> Items { get; } = new();
        public List<ItemAllergen> ItemsAllergen { get; } = new();
    }
}
