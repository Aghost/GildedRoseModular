using System;
using System.Collections.Generic;

using static System.Console;

namespace GildedRose.Core.Models
{
    public class NormalItem : Item
    {
        private List<Delegate> Attributes = new();

        public NormalItem(string name, int sellIn, int quality, List<Delegate> attributes) : base(name, sellIn, quality) {
            Attributes = attributes;
        }

        public override void Update() {
            foreach (Action<Item> a in Attributes) {
                a(this);
            }
        }

        public void GetMethods() {
            foreach (var attrib in Attributes) {
                switch (attrib.Method.Name) {
                    case "<.cctor>b__7_0" : WriteLine("\tNormalQuality"); break;
                    case "<.cctor>b__7_1" : WriteLine("\tConjuredQuality"); break;
                    case "<.cctor>b__7_2" : WriteLine("\tVintageQuality"); break;
                    case "<.cctor>b__7_3" : WriteLine("\tExpiringQuality"); break;
                    case "<.cctor>b__7_4" : WriteLine("\tClampQuality"); break;
                    case "<.cctor>b__7_5" : WriteLine("\tAging"); break;
                    case "<.cctor>b__7_6" : WriteLine("\tAllInOne"); break;
                    default: WriteLine($"\tMethodName {attrib.Method.Name} Not Recognized..."); break;
                }
            }
        }
    }
}
