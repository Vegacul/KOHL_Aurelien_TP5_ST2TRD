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

        private bool RespectMINQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool RespectMAXQuality(Item item)
        {
            return item.Quality < 50;
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
        private void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private void UpdateSellIn(Item item)
        {
            /// ON PASSE LA DATE SI PAS LEGEND
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                DecreaseSellIn(item);
            }
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {

                

                /// POUR LES OBJET QUI BAISSE EN VALEUR

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (RespectMINQuality(item))
                    {
                        /// POUR LES OBJET QUI BAISSE EN VALEUR
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            DecreaseQuality(item);
                        }
                    }
                }
                /// POUR LES OBJET QUI monte EN VALEUR
                else
                {
                    /// LA QUALITE MONTE DE UN POUR TOUS 
                    if (RespectMAXQuality(item))
                    {
                        IncreaseQuality(item);

                        /// SI CONCERT ALORS 
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            /// SI RESTE 10 JOUR ON AJOUTE UN DONC TOTAL PLUS 2
                            if (item.SellIn < 11)
                            {
                                if (RespectMAXQuality(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }
                            /// SI RESTE 5 JOUR ON AJOUTE UN DONC TOTAL PLUS 3
                            if (item.SellIn < 6)
                            {
                                if (RespectMAXQuality(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }
                        }
                    }
                }

                UpdateSellIn(item);


                /// QUAND LA DATE EST PASSE
                if (item.SellIn < 0)
                {
                    /// SI C4EST PAS DU FROMAGE LA QUALITE VA BAISSER
                    if (item.Name != "Aged Brie")
                    {
                        /// POUR TOUT LES OBJET SAUF CONCERT ELLE DESCENT FUR ET A MESURE
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (RespectMINQuality(item))
                            {
                                /// POUR TOUT LES OBJET SAUF SULFURAS ELLE DESCENT FUR ET A MESURE
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    DecreaseQuality(item);
                                }
                            }
                        }
                        /// SI CONCERT DIRECT ENVOYER A ZERO
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    /// SI CEST  DU FROMAGE LA QUALITE VA AUGMENTER
                    else
                    {
                        if (RespectMAXQuality(item))
                        {
                            IncreaseQuality(item);
                        }
                    }
                    

                }
            }
        }
    }
}
