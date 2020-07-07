namespace Autofac.Extensions.TypedFactories.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryMergeExtension
    {
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            Dictionary<TKey, TValue> otherDictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            if (otherDictionary == null)
                throw new ArgumentNullException(nameof(otherDictionary));

            foreach (KeyValuePair<TKey, TValue> keyValuePair in otherDictionary)
            {
                if (!dictionary.ContainsKey(keyValuePair.Key))
                {
                    dictionary.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return dictionary;
        }
    }
}
