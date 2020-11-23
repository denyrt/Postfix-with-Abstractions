namespace Core.Contracts
{
    public interface IOperationLexeme<T> : ILexeme<T> where T : struct
    {
        public string Key { get; }

        public int Priority { get; }        
    }
}
