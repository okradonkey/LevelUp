using UnityEngine;
using Verse;

namespace LevelUp
{
    [StaticConstructorOnStartup]
    public static class GUIAssets
    {
        public readonly static Texture2D AnimationIcon = ContentFinder<Texture2D>.Get("LevelUp/UI/AnimationIcon");
        public readonly static Texture2D PlayIcon = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Play");
        public readonly static Texture2D ArrowUpIcon = ContentFinder<Texture2D>.Get("UI/Buttons/ReorderUp");
        public readonly static Texture2D ArrowDownIcon = ContentFinder<Texture2D>.Get("UI/Buttons/ReorderDown");
        public readonly static Texture2D PlusOneIcon = ContentFinder<Texture2D>.Get("LevelUp/UI/PlusOneIcon");
        public readonly static Texture2D MinusOneIcon = ContentFinder<Texture2D>.Get("LevelUp/UI/MinusOneIcon");
        public readonly static Color PawnName = GenColor.FromHex("d09b61");
        public readonly static Color RimYellow = GenColor.FromHex("FFDC39");
    }
}