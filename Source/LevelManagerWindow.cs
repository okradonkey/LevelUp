using System.Linq;
using UnityEngine;
using Verse;

namespace LevelUp
{
    public class LevelManagerWindow : Window
    {
        public LevelManagerWindow()
        {
            this.gameHandler = Current.Game.GetComponent<GameHandler>();
            this.doCloseX = true;
            this.absorbInputAroundWindow = false;
            this.preventCameraMotion = false;
        }

        private readonly GameHandler gameHandler;
        private const float Padding = 8f;
        private const float RowHeight = 30f;

        public override Vector2 InitialSize => new Vector2(360f, 170f);

        protected override void SetInitialSizeAndPosition()
        {
            this.windowRect = new Rect(UI.screenWidth - InitialSize.x, UI.screenHeight - 35f - InitialSize.y, InitialSize.x, InitialSize.y);
        }

        public override void DoWindowContents(Rect rect)
        {
            var rowRect = new Rect(rect.x, rect.y, rect.width, RowHeight);

            Text.Font = GameFont.Small;
            Widgets.Label(rowRect, "Level Up!");

            rowRect.y += rowRect.height;
            DrawLevelContent(rowRect, GUIAssets.PlusOneIcon, this.gameHandler.LevelUpInfo);
            rowRect.y += rowRect.height;
            Widgets.DrawLightHighlight(rowRect);
            DrawLevelContent(rowRect, GUIAssets.MinusOneIcon, this.gameHandler.LevelDownInfo);
        }

        private void DrawLevelContent(Rect rect, Texture2D icon, LevelingInfo levelingInfo)
        {
            var elementRect = new Rect(rect.x, rect.y, rect.height, rect.height);
            Widgets.DrawTextureFitted(elementRect, icon, 1f);

            var isActive = levelingInfo.Active;
            Widgets.Checkbox(elementRect.x + elementRect.width * 0.4f + Padding, elementRect.y + elementRect.height * 0.4f, ref levelingInfo.Active, elementRect.height * 0.6f);
            if (levelingInfo.Active != isActive)
            {
                SkillRecordLearnPatch.ReApplyPatch();
            }

            elementRect.x += elementRect.xMax + Padding;

            var testPlayRect = new Rect(elementRect.x, elementRect.y, elementRect.height, elementRect.height);

            Widgets.DrawTextureFitted(testPlayRect, GUIAssets.AnimationIcon, 1f);
            var playIconRect = new Rect(testPlayRect.x + testPlayRect.width / 2, testPlayRect.y + testPlayRect.height / 2, testPlayRect.width / 2, testPlayRect.height / 2);

            var color = GUI.color;
            if (Find.Selector.FirstSelectedObject is Pawn pawn && pawn.IsFreeColonist)
            {
                var num = Pulser.PulseBrightness(0.5f, Pulser.PulseBrightness(0.5f, 0.6f));
                GUI.color = new Color(num, num, num) * GUIAssets.RimYellow;

                if (Widgets.ButtonInvisible(testPlayRect))
                {
                    var skill = pawn.skills.skills.First(x => !x.TotallyDisabled);
                    LevelActionTrigger.Trigger(levelingInfo, skill, pawn);
                }
            }
            else
            {
                GUI.color = Color.grey;
                if (Widgets.ButtonInvisible(testPlayRect))
                {
                    Find.Selector.Select(Find.CurrentMap.mapPawns.FreeColonists.First());
                }
            }
            Widgets.DrawTextureFitted(playIconRect, GUIAssets.PlayIcon, 1f);
            GUI.color = color;

            elementRect.x = elementRect.xMax + Padding;
            elementRect.width = rect.width - elementRect.x;

            var textSize = Text.CalcSize(levelingInfo.Effect.defName);
            var labelRect = new Rect(elementRect.x, elementRect.y + elementRect.height / 2 - textSize.y / 2, Mathf.Max(textSize.x, elementRect.width), elementRect.height);

            if (Widgets.ButtonText(labelRect, levelingInfo.Effect.label.CapitalizeFirst(), false))
            {
                Find.WindowStack.Add(levelingInfo.Menu);
            }
        }
    }
}