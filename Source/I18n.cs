using Verse;

namespace LevelUp
{
    public static class I18n
    {
        public static string Translate(string key)
        {
#if NET472

            return key.TranslateSimple();
#else

            return key.Translate();
#endif
        }
    }
}