using Core.Contracts;
using System;
using System.Collections.Generic;

namespace Core
{
    public class LexemeRelations<T> where T : struct
    {
        public IOperationLexeme<T> Current { get; }

        public List<IOperationLexeme<T>> NotAllowedAfterCurrent { get; }

        public LexemeRelations(IOperationLexeme<T> current, IEnumerable<IOperationLexeme<T>> notAllowedAfterCurrent)
        {
            if (current is null)
                throw new ArgumentNullException(nameof(current), "Value was null");

            if (notAllowedAfterCurrent is null)
                throw new ArgumentNullException(nameof(notAllowedAfterCurrent), "Value was null");

            Current = current;
            NotAllowedAfterCurrent = new List<IOperationLexeme<T>>(notAllowedAfterCurrent);
        }
    }
}
