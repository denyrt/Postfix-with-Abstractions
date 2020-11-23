namespace Core.Contracts
{
    public interface IOpenTagLexeme<T> : IOperationLexeme<T> where T : struct
    {        
        public ICloseTagLexeme<T> CloseTag { get; set; }
    }
}
