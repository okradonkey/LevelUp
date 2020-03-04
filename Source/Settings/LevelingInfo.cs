using Verse;

namespace LevelUp
{
    // MAKE INTO ONE NON ABSTRACT CLASS AND DEFINE DEFAULTS IN GAMEHANDLER INSTEAD.
    public abstract class LevelingInfo : IExposable
    {
        private bool active;
        private float volume;
        private LevelSoundDef sound;
        private AnimationDef animation;
        private MessageDef message;
        private string messageText;
        public ref bool Active => ref active;
        public ref float Volume => ref volume;
        public ref LevelSoundDef Sound => ref sound;
        public ref AnimationDef Animation => ref animation;
        public ref MessageDef Message => ref message;
        public ref string MessageText => ref messageText;

        public void ExposeData()
        {
            Scribe_Values.Look(ref active, nameof(Active));
            Scribe_Values.Look(ref volume, nameof(Volume), 25f);
            Scribe_Values.Look(ref messageText, nameof(MessageText));
            Scribe_Defs.Look(ref animation, nameof(Animation));
            Scribe_Defs.Look(ref sound, nameof(Sound));
            Scribe_Defs.Look(ref message, nameof(Message));
        }

        public abstract void SetDefaults();
    }
}