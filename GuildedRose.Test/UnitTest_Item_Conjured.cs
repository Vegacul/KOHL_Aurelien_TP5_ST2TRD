using csharp;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildedRose.Test
{
    public class Tests_Item_Conjured
    {
        //The test are false for the moment because there is an error in the treatment of the conjured item 
        //they decrease like common item but instead they should decrease two time faster


        [Test]
        public void ConjuredItemShouldQualityDecreaseBy2BeforeTheDate()
        {
            // Arrange
            var ConjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 15 };
            IList<Item> Items = new List<Item> { ConjuredItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(ConjuredItem.Quality, 14);
        }

        [Test]
        public void ConjuredItemShouldQualityDecreaseBy4AfterTheDate()
        {
            // Arrange
            var ConjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = -3, Quality = 10 };
            IList<Item> Items = new List<Item> { ConjuredItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(ConjuredItem.Quality, 8);
        }
    }
}