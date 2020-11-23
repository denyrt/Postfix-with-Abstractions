namespace Core.Contracts
{
    public interface ICloseTagLexeme<T> : IOperationLexeme<T> where T : struct
    {        
        public IOpenTagLexeme<T> OpenTag { get; set; }
    }
}
