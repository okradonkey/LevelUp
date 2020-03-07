using RimWorld;
using Verse;

namespace LevelUp
{
    public class MainButtonWorker_LevelUp : MainButtonWorker
    {
        private Window levelManagerWindow;

        public override void Activate()
        {
            Find.WindowStack.Add(this.levelManagerWindow ??= new LevelManagerWindow());
        }
    }
}