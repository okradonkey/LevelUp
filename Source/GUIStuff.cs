using UnityEngine;
using Verse;

namespace LevelUp
{
    [StaticConstructorOnStartup]
    public static class GUIStuff
    {
        public readonly static Texture2D AnimationIcon = ContentFinder<Texture2D>.Get("AnimationIcon");
        public readonly static Texture2D PlayIcon = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Play");
        public readonly static Color PawnName = GenColor.FromHex("d09b61");
        public readonly static Color RimYellow = GenColor.FromHex("FFDC39");
    }
}