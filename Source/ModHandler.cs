using Verse;

namespace LevelUp
{
    public class ModHandler : Mod
    {
        //private const float RowHeight = 24f;

        public ModHandler(ModContentPack content) : base(content)
        { }

        private Settings Settings => this.GetSettings<Settings>();

        public override string SettingsCategory() => this.Content.Name;

        /*
        public override void DoSettingsWindowContents(Rect rect)
        {
            var optionsRect = rect.TopHalf();
            var doLevelUp = this.Settings.DoLevelUp;
            var doLevelDown = this.Settings.DoLevelDown;
            var sideRect = new Rect(optionsRect.x, optionsRect.y, 100f, optionsRect.height);
            var levelUpContentRect = new Rect(sideRect.xMax, optionsRect.y, (optionsRect.width - sideRect.width) / 2, optionsRect.height);
            var levelDownContentRect = new Rect(levelUpContentRect.xMax, optionsRect.y, levelUpContentRect.width, optionsRect.height);

            DrawSideBox(sideRect);

            Action<LevelSoundDef> setLevelUpSoundDef = (LevelSoundDef def) => Settings.LevelUpSound = def;
            Action<AnimationDef> setLevelUpAnimationDef = (AnimationDef def) => Settings.LevelUpAnimation = def;
            DrawSettingsBox(levelUpContentRect, "Krafs.LevelUp.LevelUpLabel", ref this.Settings.DoLevelUp, setLevelUpAnimationDef, Settings.LevelUpAnimation, setLevelUpSoundDef, Settings.LevelUpSound, ref Settings.LevelUpSoundVolume);

            Action<LevelSoundDef> setLevelDownSoundDef = (LevelSoundDef def) => Settings.LevelDownSound = def;
            Action<AnimationDef> setLevelDownAnimationDef = (AnimationDef def) => Settings.LevelDownAnimation = def;
            DrawSettingsBox(levelDownContentRect, "Krafs.LevelUp.LevelDownLabel", ref this.Settings.DoLevelDown, setLevelDownAnimationDef, Settings.LevelDownAnimation, setLevelDownSoundDef, Settings.LevelDownSound, ref Settings.LevelDownSoundVolume);

            if (doLevelUp != this.Settings.DoLevelUp || doLevelDown != this.Settings.DoLevelDown)
            {
                SkillRecordLearnPatch.UpdatePatch();
            }
        }

        private void DrawSideBox(Rect rect)
        {
            var rowRect = new Rect(rect.x, rect.y + RowHeight, rect.width, RowHeight);
            Widgets.Label(rowRect, "Animation");
            rowRect.y += RowHeight;
            Widgets.Label(rowRect, "Sound");
        }

        private void DrawSettingsBox(Rect rect, string languageKey, ref bool checkon, Action<AnimationDef> animationSetter, AnimationDef animationDef, Action<LevelSoundDef> soundSetter, SoundDef soundDef, ref float levelSoundVolume)
        {
            var menuRect = rect.GetInnerRect();
            Widgets.DrawMenuSection(menuRect);
            var contentRect = menuRect.GetInnerRect();
            var labelRect = new Rect(contentRect.x, contentRect.y, contentRect.width, RowHeight);
            Widgets.CheckboxLabeled(labelRect, languageKey.Translate(), ref checkon);
            var animationButtonRect = new Rect(contentRect.x, labelRect.yMax, contentRect.width, RowHeight);

            var color = GUI.color;
            GUI.color = checkon ? Color.white : Color.grey;

            if (Widgets.ButtonText(animationButtonRect, animationDef.LabelCap, true, false, checkon))
            {
                var options = new List<FloatMenuOption>();
                foreach (var def in DefDatabase<AnimationDef>.AllDefs)
                {
                    options.Add(new FloatMenuOption(def.LabelCap, () => animationSetter(def)));
                }

                var floatMenu = new FloatMenu(options);
                Find.WindowStack.Add(floatMenu);
            }

            var soundRect = new Rect(contentRect.x, animationButtonRect.yMax, contentRect.width, RowHeight);
            var soundMenuRect = new Rect(soundRect.x, soundRect.y, soundRect.width / 3, RowHeight);
            if (Widgets.ButtonText(soundMenuRect, soundDef.LabelCap, true, false, checkon))
            {
                var options = new List<FloatMenuOption>();
                foreach (var def in DefDatabase<LevelSoundDef>.AllDefs)
                {
                    options.Add(new FloatMenuOption(def.LabelCap, () => soundSetter(def)));
                }

                var floatMenu = new FloatMenu(options);
                Find.WindowStack.Add(floatMenu);
            }

            var soundPlayButtonRect = new Rect(soundMenuRect.xMax, soundRect.y, 30f, RowHeight).ContractedBy(2f);
            if (Widgets.ButtonImageFitted(soundPlayButtonRect, ContentFinder<Texture2D>.Get("NoteIcon")))
            {
                var soundInfo = SoundInfo.OnCamera(MaintenanceType.None);
                soundInfo.volumeFactor = levelSoundVolume;
                soundDef.PlayOneShot(soundInfo);
            }

            var volumeSliderRect = new Rect(soundPlayButtonRect.x + soundPlayButtonRect.width + 10f, soundRect.y + RowHeight / 2, (soundRect.x + soundRect.width) - (soundPlayButtonRect.x + soundPlayButtonRect.width + 10f) - 10f, RowHeight);
            levelSoundVolume = Widgets.HorizontalSlider(volumeSliderRect, levelSoundVolume, 0f, 2.5f);

            GUI.color = color;
        }
        */
    }
}