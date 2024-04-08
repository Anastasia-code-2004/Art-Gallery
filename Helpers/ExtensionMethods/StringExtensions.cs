using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryApp.Helpers.ExtensionMethods
{
    internal static class StringExtensions
    {
        public static Color ToColorFromResourceKey(this string resourceKey)
        {
            return Application.Current.Resources
                .MergedDictionaries.First()[resourceKey] as Color;
        }
    }
}
