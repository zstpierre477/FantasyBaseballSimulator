using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FantasyBaseball.UI.Extensions
{
    public static class Extensions
    {
        public static void Order<TSource, TKey>(this ObservableCollection<TSource> observableCollection, Func<TSource, TKey> keySelector, bool descending = false)
        {
            ObservableCollection<TSource> temp;
            if (descending)
            {
                temp = new ObservableCollection<TSource>(observableCollection.OrderByDescending(keySelector));
            }
            else
            {
                temp = new ObservableCollection<TSource>(observableCollection.OrderBy(keySelector));
            }
            observableCollection.Clear();
            foreach (var obj in temp)
            {
                observableCollection.Add(obj);
            }
        }
    }
}
