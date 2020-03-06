using UnityEngine;
using Verse;

namespace LevelUp
{
    public class LevelManagerWindow : Window
    {
        public LevelManagerWindow()
        {
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
            var rowRect = new Rect(rect.x, rect.y, rect.width / 2, 24f);

            var isActive = this.currentLevelInfo.Active;

            Widgets.Checkbox(rowRect.x, rowRect.y, ref this.currentLevelInfo.Active);

            if (this.currentLevelInfo.Active != isActive)
            {
                SkillRecordLearnPatch.ReApplyPatch();
            }

            rowRect.y += 24f;
        }
    }
}