namespace Core.Contracts
{
    public interface IUnknownOperant<T> : IOperantLexeme<T> where T : struct
    {        
        public string UniqueTag { get; set; }

        public double PowValue { get; set; }
    }
}
