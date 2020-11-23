using Core.Contracts;
using System;

namespace Core.Lexemes
{
    public class OpenTagLexeme<T> : IOpenTagLexeme<T> where T : struct
    {
        public ICloseTagLexeme<T> CloseTag { get; set; }

        public string Key { get; }

        public int Priority { get; }

        public OpenTagLexeme(string key, int priority)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));

            Key = key;
            Priority = priority;
        }
    }
}
