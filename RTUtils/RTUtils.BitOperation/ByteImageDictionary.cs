using System;
using System.Collections.Generic;
using LanguageExt;

namespace RTUtils.BitOperation
{
    public class ByteImageDictionary
    {
        protected Dictionary<string, int> NameToPositionMapping { get; set; } = new Dictionary<string, int>();

        private ByteImageDictionary()
        {
        }

        protected void AddMap(string name, int index)
        {
            this.NameToPositionMapping.Add(name, index);
        }

        public static ByteImageDictionary Create(params Map[] maps)
        {
            var dict = new ByteImageDictionary();
            foreach (var map in maps)
            {
                dict.AddMap(map.Name, map.Index);
            }

            return dict;
        }

        public Option<int> GetIndex(string name)
        {
            if (NameToPositionMapping.ContainsKey(name))
            {
                return NameToPositionMapping[name];
            }

            return Option<int>.None;
        }
    }
}