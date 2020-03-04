using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace LevelUp
{
    public class LevelManagerWindow : Window
    {
        public LevelManagerWindow()
        {
            this.resizeable = true;
            this.draggable = true;

            var gameHandler = Current.Game.GetComponent<GameHandler>();
            this.levelUpInfo = gameHandler.LevelUpInfo;
            this.levelDownInfo = gameHandler.LevelDownInfo;
            this.currentLevelInfo = this.levelUpInfo;
        }

        public override Vector2 InitialSize => new Vector2(500f, 260f);

        private const float Padding = 8f;
        private LevelingInfo currentLevelInfo;
        private LevelingInfo levelUpInfo;
        private LevelingInfo levelDownInfo;

        protected override void SetInitialSizeAndPosition()
        {
            this.windowRect = new Rect(0, UI.screenHeight - 35f - InitialSize.y, InitialSize.x, InitialSize.y);
        }

        public override void DoWindowContents(Rect rect)
        {
            Text.Font = GameFont.Small;
            var tabRect = new Rect(rect.x, rect.y, rect.width, 24f);
            var levelUpLabelRect = new Rect(tabRect.x, tabRect.y, Text.CalcSize("Level up").x + 15f, tabRect.height);
            Widgets.DrawLightHighlight(levelUpLabelRect);

            if (Widgets.ButtonText(levelUpLabelRect, "Level up"))
            {
                this.currentLevelInfo = this.levelUpInfo;
            }

            var levelDownLabelRect = new Rect(levelUpLabelRect.xMax, tabRect.y, Text.CalcSize("Level down").x + 15f, tabRect.height);
            if (Widgets.ButtonText(levelDownLabelRect, "Level down"))
            {
                this.currentLevelInfo = this.levelDownInfo;
            }

            var contentRect = new Rect(rect.x, rect.y + tabRect.height + Padding, rect.width, rect.height - tabRect.height - Padding);

            DrawLevelContent(contentRect);
        }

        private void DrawLevelContent(Rect rect)
        {
            var textHeight = Text.CalcSize("Bright Bubble").y; // When should I do this? Once or everytime?

            var rowRect = new Rect(rect.x, rect.y, rect.width / 2, 24f);



            //
            //var rightRowRect = new Rect(rowRect);
            //rightRowRect.x = rowRect.xMax;

            //var leftCheckboxRect = rightRowRect.LeftHalf();
            //var rightCheckboxRect = rightRowRect.RightHalf();

            var isActive = this.currentLevelInfo.Active;
            //var levelDownHasChanged = this.levelDownInfo.Active;
            Widgets.Checkbox(rowRect.x, rowRect.y, ref this.currentLevelInfo.Active);
            //Widgets.Checkbox(rightCheckboxRect.x, rightCheckboxRect.y, ref this.levelDownInfo.Active);
            if (this.currentLevelInfo.Active != isActive)
            {
                SkillRecordLearnPatch.UpdatePatch();
            }

            //

            rowRect.y += 24f;

            Widgets.DrawLightHighlight(rowRect);

            // ANIMATION
            var animationRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);
            var animationIconRect = new Rect(animationRect.x, animationRect.y, animationRect.height, animationRect.height);
            Widgets.DrawTextureFitted(animationIconRect, Textures.AnimationIcon, 1f);

            var animationLabelRect = new Rect(animationIconRect.xMax + Padding, animationRect.y + animationRect.height / 2 - textHeight / 2, animationRect.width - animationIconRect.width - Padding, animationRect.height);
            Widgets.Label(animationLabelRect, currentLevelInfo.Animation.LabelCap);
            if (Widgets.ButtonInvisible(animationLabelRect))
            {
                var options = new List<FloatMenuOption>();
                foreach (var def in DefDatabase<AnimationDef>.AllDefs)
                {
                    options.Add(new FloatMenuOption(def.LabelCap, () => this.currentLevelInfo.Animation = def));
                }

                var floatMenu = new FloatMenu(options);
                Find.WindowStack.Add(floatMenu);
            }

            rowRect.y += 24f;

            // SOUND
            var soundRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);
            var noteIconRect = new Rect(soundRect.x, soundRect.y, soundRect.height, soundRect.height);
            Widgets.DrawTextureFitted(noteIconRect, Textures.NoteIcon, 0.8f);

            var soundLabelRect = new Rect(noteIconRect.xMax + Padding, soundRect.y + soundRect.height / 2 - textHeight / 2, soundRect.width - noteIconRect.width - Padding, soundRect.height);
            Widgets.Label(soundLabelRect, currentLevelInfo.Sound.LabelCap);
            if (Widgets.ButtonInvisible(soundLabelRect))
            {
                var options = new List<FloatMenuOption>();
                foreach (var def in DefDatabase<LevelSoundDef>.AllDefs)
                {
                    options.Add(new FloatMenuOption(def.LabelCap, () => this.currentLevelInfo.Sound = def));
                }

                var floatMenu = new FloatMenu(options);
                Find.WindowStack.Add(floatMenu);
            }

            rowRect.y += 24f;
            Widgets.DrawLightHighlight(rowRect);

            // VOLUME
            var volumeRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);
            var volumeIconRect = new Rect(volumeRect.x, volumeRect.y, volumeRect.height, volumeRect.height);
            var soundIcon = this.currentLevelInfo.Volume > 0 ? Textures.SoundOnIcon : Textures.SoundOffIcon;
            Widgets.DrawTextureFitted(volumeIconRect, soundIcon, 0.9f);
            var volumeSliderRect = new Rect(volumeIconRect.xMax + Padding, volumeRect.y, volumeRect.width - volumeIconRect.width - Padding * 2, volumeRect.height);
            this.currentLevelInfo.Volume = Widgets.HorizontalSlider(volumeSliderRect, this.currentLevelInfo.Volume, 0f, 2.5f, true);

            rowRect.y += 24f;

            // MESSAGE
            var messageRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);
            var messageIconRect = new Rect(messageRect.x, messageRect.y, messageRect.height, messageRect.height);
            Widgets.DrawTextureFitted(messageIconRect, Textures.MessageBubbleIcon, 0.9f);

            var messageLabelRect = new Rect(messageIconRect.xMax + Padding, messageRect.y + messageRect.height / 2 - textHeight / 2, messageRect.width - messageIconRect.width - Padding, messageRect.height);
            Widgets.Label(messageLabelRect, currentLevelInfo.Message.LabelCap);
            if (Widgets.ButtonInvisible(messageLabelRect))
            {
                var options = new List<FloatMenuOption>();
                foreach (var def in DefDatabase<MessageDef>.AllDefs)
                {
                    options.Add(new FloatMenuOption(def.LabelCap, () => this.currentLevelInfo.Message = def));
                }

                var floatMenu = new FloatMenu(options);
                Find.WindowStack.Add(floatMenu);
            }

            rowRect.y += 24f;
            Widgets.DrawLightHighlight(rowRect);

            // EDIT TEXT
            var textEditRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);

            var message = isEditingMessage ? textBuffer : this.currentLevelInfo.MessageText;
            if (Find.Selector.FirstSelectedObject is Pawn pawn && pawn.IsFreeColonist)
            {
                message = TextModifier.Replace(message, pawn: pawn); // Will fail on animals
            }
            var messageWidth = Text.CalcSize(message).x;
            var textLabelRect = new Rect(textEditRect.height + Padding, textEditRect.y + textEditRect.height / 2 - textHeight / 2, messageWidth, textEditRect.height);

            Widgets.Label(textLabelRect, message);

            var textEditIconRect = new Rect(textLabelRect.xMax + Padding, textEditRect.y, textEditRect.height, textEditRect.height);
            Widgets.DrawTextureFitted(textEditIconRect, Textures.EditIcon, 0.6f);
            if (Widgets.ButtonInvisible(textEditIconRect))
            {
                textBuffer = this.currentLevelInfo.MessageText;
                isEditingMessage = true;
            }

            if (isEditingMessage)
            {
                rowRect.y += 24f;

                var textInputRect = new Rect(rowRect.x, rowRect.y, rowRect.width, rowRect.height);
                var textFieldRect = new Rect(textInputRect.height + Padding, textInputRect.y + textInputRect.height / 2 - textHeight / 2, textLabelRect.width, textInputRect.height);
                textBuffer = Widgets.TextField(textFieldRect, textBuffer);

                var saveIconRect = new Rect(textFieldRect.xMax + Padding, textInputRect.y, textInputRect.height, textInputRect.height);
                Widgets.DrawTextureFitted(saveIconRect, Textures.SaveIcon, 0.8f);
                if (Widgets.ButtonInvisible(saveIconRect))
                {
                    isEditingMessage = false;
                    this.currentLevelInfo.MessageText = textBuffer;
                    textBuffer = null;
                }
            }
        }

        private string textBuffer;
        private bool isEditingMessage = false;
    }
}