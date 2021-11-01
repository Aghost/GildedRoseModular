using System;

namespace GildedRose.Core.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public string ToStr => $"{Name}, {SellIn}, {Quality}";

        protected Item(string name, int sellIn, int quality) {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public abstract void Update();
    }
}
