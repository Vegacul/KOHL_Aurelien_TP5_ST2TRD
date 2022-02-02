using csharp;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildedRose.Test
{
    public class Tests_Item_Legend
    {


        [Test]
        public void SulfurasShouldNotChangeInQuality()
        {
            // Arrange
            var classicItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 25, Quality = 80 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.Quality, 80);
        }

        [Test]
        public void SulfurasShouldNotChangeInDate()
        {
            // Arrange
            var classicItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 25, Quality = 80 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.SellIn, 25);
        }
    }
}