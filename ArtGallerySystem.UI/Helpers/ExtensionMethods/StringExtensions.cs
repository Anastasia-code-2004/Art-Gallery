namespace ArtGallerySystem.UI.Helpers.ExtensionMethods
{
    internal static class StringExtensions
    {
        public static Color ToColorFromResourceKey(this string resourceKey)
        {
            return Microsoft.Maui.Controls.Application.Current.Resources
                .MergedDictionaries.First()[resourceKey] as Color;
        }
    }
}

