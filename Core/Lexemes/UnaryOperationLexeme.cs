using Core.Contracts;
using System;

namespace Core.Lexemes
{
    public class UnaryOperationLexeme<T> : IUnaryOperationLexeme<T> where T : struct
    {        
        public string Key { get; }

        public int Priority { get; }

        public Func<IOperantLexeme<T>, IOperantLexeme<T>> Function { get; }

        public UnaryOperationLexeme(string key, int priority, Func<IOperantLexeme<T>, IOperantLexeme<T>> function)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be empty or null.", nameof(key));

            if (function is null)
                throw new ArgumentNullException(nameof(function), "Function was null.");

            Key = key;
            Priority = priority;
            Function = function;
        }
    }
}
