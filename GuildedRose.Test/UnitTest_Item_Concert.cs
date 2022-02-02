using csharp;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildedRose.Test
{
    public class Tests_Item_Concert
    {
        [Test]
        public void ConcertItemQualityShouldIncreaseByOneWithTime()
        {
            // Arrange
            var concertItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 18 };
            IList<Item> Items = new List<Item> { concertItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(concertItem.Quality, 19);
        }

        [Test]
        public void ConcertItemQualityShouldIncreaseByTwoIfDateInfTo10()
        {
            // Arrange
            var concertItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 18 };
            IList<Item> Items = new List<Item> { concertItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(concertItem.Quality, 20);
        }

        [Test]
        public void ConcertItemQualityShouldIncreaseByTreeIfDateInfTo5()
        {
            // Arrange
            var concertItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 17 };
            IList<Item> Items = new List<Item> { concertItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(concertItem.Quality, 20);
        }
    }
}