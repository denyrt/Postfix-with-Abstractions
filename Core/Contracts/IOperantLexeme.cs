namespace Core.Contracts
{
    public interface IOperantLexeme<T> : ILexeme<T> where T : struct
    {
        public T Value { get; set; }
    }
}
