using System;

namespace Core.Contracts
{
    public interface IUnknownUnaryOperation<T> where T : struct
    {
        public Func<bool, IOperantLexeme<T>> CanCalculateWithUnknown { get; set; }

        public Func<IOperantLexeme<T>, IOperantLexeme<T>> FuncWithUnknonw { get; set; }
    }
}
