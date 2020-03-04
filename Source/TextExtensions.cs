using UnityEngine;

namespace LevelUp
{
    public static class TextExtensions
    {
        public static string Colorize(this string text, Color color)
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(color), text);
        }
    }
}