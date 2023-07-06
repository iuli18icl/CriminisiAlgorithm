using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CriminisiAlgorithm
{
    public static class RandomColorGenerator
    {
        private static List<KnownColor> colorList = Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>().ToList();
        private static Random rand = new Random(DateTime.Now.Ticks.GetHashCode());
        private static int maxColorIndex => colorList.Count();
        public static Color GetRandomColor()
        {
            return Color.FromKnownColor(colorList[rand.Next(0, maxColorIndex)]);
        }
    }
}
