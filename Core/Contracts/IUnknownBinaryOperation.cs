using System;

namespace Core.Contracts
{
    public interface IUnknownBinaryOperation<T> where T : struct
    {
        public Func<IOperantLexeme<T>, IOperantLexeme<T>, bool> CanCalculateWithUnknown { get; set; }

        public Func<IOperantLexeme<T>, IOperantLexeme<T>, IOperantLexeme<T>> FuncWithUnknown { get; set; }
    }
}
