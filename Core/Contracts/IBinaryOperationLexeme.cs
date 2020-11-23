using System;

namespace Core.Contracts
{
    public interface IBinaryOperationLexeme<T> : IOperationLexeme<T> where T : struct
    {
        public Func<IOperantLexeme<T>, IOperantLexeme<T>, IOperantLexeme<T>> Function { get; }
    }
}
