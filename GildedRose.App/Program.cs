using System;
using System.Collections.Generic;
using GildedRose.Core.Models;

using static GildedRose.Core.LogicDelegates.ActionAttributes;
using static System.Console;

namespace GildedRose.App
{
    class Program
    {
        static void Main(string[] args) {
            WriteLine("OMGHAI!");

            List<Item> Items = new List<Item>() {
                new NormalItem("+5 Dexterity Vest", 10, 20, new() { Aging, NormalQuality, ClampQuality }),
                new NormalItem("Aged Brie", 2, 0, new() { Aging, VintageQuality, ClampQuality }),
                new NormalItem("Elixir of the Mongoose", 5, 7, new() { Aging, NormalQuality, ClampQuality }),
                new NormalItem("Sulfuras, Hand of Ragnaros", 0, 80, new()),
                new NormalItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, new() { Aging, ExpiringQuality, ClampQuality }),
                new NormalItem("Conjured Mana Cake", 3, 6, new() { Aging, ConjuredQuality, ClampQuality })
            };

            /*
            List<Item> Items = new List<Item>() {
                new NormalItem("+5 Dexterity Vest", 10, 20, new() { AllInOne }),
                new NormalItem("Aged Brie", 2, 0, new() { AllInOne }),
                new NormalItem("Elixir of the Mongoose", 5, 7, new() { AllInOne }),
                new NormalItem("Sulfuras, Hand of Ragnaros", 0, 80, new() { AllInOne }),
                new NormalItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, new() { AllInOne }),
                new NormalItem("Conjured Mana Cake", 3, 6, new() { AllInOne })
            };
            */

            int days = 30;
            for (int i = 0; i <= days; i++) {
                WriteLine($"-------- day {i} --------");
                WriteLine("name, sellIn, quality");

                foreach (NormalItem item in Items) {
                    WriteLine(item.ToStr);
                    //item.GetMethods();
                    item.Update();
                }

                WriteLine("");
            }
        }

    }
}
