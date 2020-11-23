using Core.Contracts;
using System.Collections.Generic;

namespace Core
{
    public class LexemeComparer<T> : IComparer<IOperationLexeme<T>> where T : struct
    {
        public LexemeComparer()
        {

        }

        public int Compare(IOperationLexeme<T> x, IOperationLexeme<T> y)
        {
            if (x.Key.Length > y.Key.Length)
                return -1;
            else if (x.Key.Length < y.Key.Length)
                return 1;
            else
                return 0;
        }
    }
}
