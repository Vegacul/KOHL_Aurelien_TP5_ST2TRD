using csharp;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildedRose.Test
{
    public class Tests_Basic_Quality
    {
        [Test]
        public void QualityShouldNotBeInfTo0()
        {
            // Arrange
            var classicItem = new Item { Name = "Elixir of the Mongoose", SellIn = -5, Quality = 1 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.Quality, 0);
        }

        [Test]
        public void QualityShouldNotBeSuppTo50()
        {
            // Arrange
            var classicItem = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.Quality, 50);
        }

        [Test]
        public void QualityShouldNotBeSuppTo50AtBegining()
        {
            // Arrange
            var classicItem = new Item { Name = "Common Item", SellIn = 5, Quality = 60 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.Quality, 49);
        }

        [Test]
        public void QualityShouldNotBeInfTo0AtBegining()
        {
            // Arrange
            var classicItem = new Item { Name = "Aged Brie", SellIn = 5, Quality = -5 };
            IList<Item> Items = new List<Item> { classicItem };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(classicItem.Quality, 1);
        }

        [Test]
        public void SulfuraShouldAlwaysBe80inQuality()
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
    }
}