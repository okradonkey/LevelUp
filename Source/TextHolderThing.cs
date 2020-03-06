using System.Reflection;
using Verse;

namespace LevelUp
{
    public class TextHolderThing : Thing
    {
        private readonly string text;

        public TextHolderThing(string text)
        {
            this.text = text;

            typeof(Thing).GetField(
                "mapIndexOrState",
                BindingFlags.Instance |
                BindingFlags.NonPublic).
                SetValue(this, (sbyte)Find.CurrentMap.Index);
        }

        public override string Label => this.text;
    }
}