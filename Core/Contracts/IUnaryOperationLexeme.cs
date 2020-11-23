using System;

namespace Core.Contracts
{
    public interface IUnaryOperationLexeme<T> : IOperationLexeme<T> where T : struct
    {
        public Func<IOperantLexeme<T>, IOperantLexeme<T>> Function { get; }
    }
}
