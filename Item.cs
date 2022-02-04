

namespace csharp
{

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public bool Conjuration { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
        ~Item()  // finalizer
        {
            // cleanup statements...
        }

        // Constructeur de l'item
        protected Item(string name, int sellIn, int quality, bool conjuration)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Conjuration = conjuration;
        }
        protected Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            if (name.Contains("Conjured"))
            {
                Conjuration = true;
                
            }
            else
            {
                Conjuration = false;
            }




        }

        /// ne fonctionne pas comme les methods CopyToX des classes filles :(
        public virtual void ChangeItemToSubitem(Item item)
        {
            string name = item.Name;
            int sellIn = item.SellIn;
            int quality = item.Quality;
            bool conjuration = item.Conjuration;

            if (name.Contains("Aged"))
            {
                new AgedBrie(name, sellIn, quality,conjuration);
            }
            else if (name.Contains("Backstage Passes"))
            {
                new BackstagePasses(name, sellIn, quality, conjuration);
            }
            else if (name.Contains("Sulfuras"))
            {
                new Sulfuras(name, sellIn, quality, conjuration);
            }
            else
            {
                new StandardItem(name, sellIn, quality, conjuration);
            }

        }

        public virtual void UpdateSellIn()
        {
            SellIn = SellIn - 1;
        }

        public virtual void UpdateQuality()
        {
            if (Quality < 0)
            {
                Quality = 0;
            }
            else if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }

    public class StandardItem : Item
    {
        public StandardItem(string name, int sellIn, int quality, bool conjuration)
            : base(name, sellIn, quality,conjuration) { }

        public StandardItem(string name, int sellIn, int quality)
    : base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            if (SellIn > 0)
            {
                Quality = Quality - 1;
                base.UpdateQuality();

                if (Conjuration == true)
                {
                    Quality = Quality - 1;
                    base.UpdateQuality();
                }
            }
            else
            {
                Quality = Quality - 2;
                base.UpdateQuality();

                if (Conjuration == true)
                {
                    Quality = Quality - 2;
                    base.UpdateQuality();
                }
            }
        }
        //   TEST AUTOMATIC CONVERSION 
        public static StandardItem CopyToStandardItem(Item item)
        {
            return new StandardItem(item.Name,item.SellIn,item.Quality,item.Conjuration);
        }
    }

    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality, bool conjuration) 
            : base(name, sellIn, quality, conjuration)
        {
        }

        public AgedBrie(string name, int sellIn, int quality): base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            if (SellIn > 0)
            {
                Quality = Quality + 1;
                base.UpdateQuality();

                if (Conjuration == true)
                {
                    Quality = Quality + 1;
                    base.UpdateQuality();
                }
            }
            else 
            {
                Quality = Quality + 2;
                base.UpdateQuality();

                if (Conjuration == true)
                {
                    Quality = Quality + 2;
                    base.UpdateQuality();
                }
            }



        }

        public static AgedBrie CopyToAgedBrie(Item item)
        {
            return new AgedBrie(item.Name, item.SellIn, item.Quality, item.Conjuration);
        }
    }

    public class BackstagePasses : Item
    {
        public BackstagePasses(string name, int sellIn, int quality, bool conjuration) : base(name, sellIn, quality, conjuration)
        {
        }
        public BackstagePasses(string name, int sellIn, int quality): base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {

            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                Quality = Quality + 3;
            }
            else if (SellIn <= 10)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality = Quality + 1;
            }
            base.UpdateQuality();

            if (Conjuration == true)
            {
                if (SellIn <= 0)
                {
                    Quality = 0;
                }
                else if (SellIn <= 5)
                {
                    Quality = Quality + 3;
                }
                else if (SellIn <= 10)
                {
                    Quality = Quality + 2;
                }
                else
                {
                    Quality = Quality + 1;
                }
                base.UpdateQuality();
            }
        }

        public static BackstagePasses CopyToBackstagePasses(Item item)
        {
            return new BackstagePasses(item.Name, item.SellIn, item.Quality, item.Conjuration);
        }
    }


    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality, bool conjuration) : base(name, sellIn, quality,conjuration)
        {
        }
        public Sulfuras(string name, int sellIn, int quality): base(name, sellIn, quality) { }

        public override void UpdateSellIn()
        {
            SellIn = SellIn;
        }

        public override void UpdateQuality()
        {
            Quality = 80;
        }

        public static Sulfuras CopyToSulfuras(Item item)
        {
            return new Sulfuras(item.Name, item.SellIn, item.Quality, item.Conjuration);
        }

    }
}
