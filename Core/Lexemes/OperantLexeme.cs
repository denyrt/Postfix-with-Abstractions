using Core.Contracts;

namespace Core.Lexemes
{
    public struct OperantLexeme<T> : IOperantLexeme<T> where T : struct
    {
        public T Value { get; set; }        

        public OperantLexeme(T value)
        {
            Value = value;
        }
    }
}
