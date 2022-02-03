using System.Collections.Generic;
using System;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }




        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                
                item.UpdateQuality();
                item.UpdateSellIn();
            }
        }
    }
}
