using System;

namespace CaDeiGreciWebsite.Data.Menu
{
    public class ItemQuality
    {
        public Int32 ItemId { get; set; }
        public Item Item { get; set; }
        public Int32 QualityId { get; set; }
        public Quality Quality { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
