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

        // Constructeur de l'item
        protected Item(string name, int sellIn, int quality, bool conjuration)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Conjuration = conjuration;
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
    }

    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality, bool conjuration) 
            : base(name, sellIn, quality, conjuration)
        {
        }

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
    }

    public class BackstagePasses : Item
    {
        public BackstagePasses(string name, int sellIn, int quality, bool conjuration) : base(name, sellIn, quality, conjuration)
        {
        }

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
    }


    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality, bool conjuration) : base(name, sellIn, quality,conjuration)
        {
        }

        public override void UpdateSellIn()
        {
            SellIn = SellIn;
        }

        public override void UpdateQuality()
        {
            Quality = 80;
        }

    }
}
