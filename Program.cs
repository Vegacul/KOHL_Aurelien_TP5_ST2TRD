﻿using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new StandardItem("+5 Dexterity Vest",10, 20,false),
                new AgedBrie("Aged Brie", 2, 0,false),
                new StandardItem("Elixir of the Mongoose", 5, 7,false),
                new Sulfuras("Sulfuras, Hand of Ragnaros",  0, 80,false),
                new Sulfuras( "Sulfuras, Hand of Ragnaros", -1, 80,false),
                new BackstagePasses
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    15,
                    20,
                    false
                ),
                new BackstagePasses
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    10,
                    49,
                    false
                ),
                new BackstagePasses
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    5,
                    49,
                    false
                ),
				// this conjured item does not work properly yet
				new StandardItem("Conjured Mana Cake", 3,6,true)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
                //Console.WriteLine("blup");
            }



           Console.ReadKey();

        }
    }
}
