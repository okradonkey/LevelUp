using UnityEngine;
using Verse;

namespace LevelUp
{
    [StaticConstructorOnStartup]
    public static class GUIStuff
    {
        public readonly static Texture2D SoundOnIcon = ContentFinder<Texture2D>.Get("SoundOnIcon");
        public readonly static Texture2D SoundOffIcon = ContentFinder<Texture2D>.Get("SoundOffIcon");
        public readonly static Texture2D EditIcon = ContentFinder<Texture2D>.Get("EditIcon");
        public readonly static Texture2D MessageBubbleIcon = ContentFinder<Texture2D>.Get("MessageBubbleIcon");
        public readonly static Texture2D NoteIcon = ContentFinder<Texture2D>.Get("NoteIcon");
        public readonly static Texture2D AnimationIcon = ContentFinder<Texture2D>.Get("AnimationIcon");
        public readonly static Texture2D SaveIcon = ContentFinder<Texture2D>.Get("SaveIcon");

        public readonly static Color PawnName = GenColor.FromHex("d09b61");
    }
}