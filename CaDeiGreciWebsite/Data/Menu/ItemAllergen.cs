using System;

namespace CaDeiGreciWebsite.Data.Menu
{
    public class ItemAllergen
    {
        public Int32 ItemId { get; set; }
        public Item Item { get; set; }
        public Int32 AllergenId { get; set; }
        public Allergen Allergen { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
