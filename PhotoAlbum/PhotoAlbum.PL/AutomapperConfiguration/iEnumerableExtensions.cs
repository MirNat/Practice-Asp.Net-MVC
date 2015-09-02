using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.PL.AutomapperConfiguration
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable,
                Action<T> action)
        {
            foreach (T item in enumerable) { action(item); }
        }
    }
}