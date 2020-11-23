using Core.Contracts;
using System;

namespace Core.Lexemes
{
    public class CloseTagLexeme<T> : ICloseTagLexeme<T> where T : struct
    {
        public string Key { get; }

        public IOpenTagLexeme<T> OpenTag { get; set; }

        public int Priority { get; }

        public CloseTagLexeme(string key, int priority)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));

            Key = key;
            Priority = priority;
        }
    }
}
