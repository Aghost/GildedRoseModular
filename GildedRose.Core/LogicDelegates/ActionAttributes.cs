using System;
using GildedRose.Core.Models;

namespace GildedRose.Core.LogicDelegates
{
    public static class ActionAttributes
    {
        public static Action<Item> NormalQuality = (item)
            => item.Quality -= item.SellIn < 0 ? 2 : 1;

        public static Action<Item> ConjuredQuality = (item)
            => item.Quality -= item.SellIn < 0 ? 4 : 2;

        public static Action<Item> VintageQuality = (item)
            => item.Quality += item.SellIn < 0 ? 2 : 1;

        public static Action<Item> ExpiringQuality = (item)
            => item.Quality = item.SellIn switch {
                                                < 0 => 0,
                                                < 5 => item.Quality + 3,
                                                < 10 => item.Quality + 2,
                                                _ => item.Quality + 1
                                            };

        public static Action<Item> ClampQuality = (item)
            => item.Quality = item.Quality < 0 ? 0 :
                                item.Quality > 50 ? 50 :
                                    item.Quality;

        public static Action<Item> Aging = (item)
            => item.SellIn--;

        public static Action<Item> AllInOne = (item)
            => {
                Aging(item);

                switch (item.Name) {
                    case "+5 Dexterity Vest": NormalQuality(item); goto clamp;
                    case "Aged Brie": VintageQuality(item); goto clamp;
                    case "Elixir of the Mongoose": NormalQuality(item); goto clamp;
                    case "Backstage passes to a TAFKAL80ETC concert": ExpiringQuality(item); goto clamp;
                    case "Conjured Mana Cake": ConjuredQuality(item); goto clamp;
                    case "Sulfuras, Hand of Ragnaros": item.SellIn++; break;
                    clamp: ClampQuality(item); break;
                    default: break;
                };

            };
    }
}
