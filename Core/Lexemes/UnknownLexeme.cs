using Core.Contracts;

namespace Core.Lexemes
{
    public class UnknownLexeme : IUnknownOperant<double>
    {
        public string UniqueTag { get; set; } = "x";
        public double PowValue { get; set; } = 1;
        public double Value { get; set; } = 1;

        public UnknownLexeme()
        {

        }

        public UnknownLexeme(double koef)
        {
            Value = koef;
        }
    }
}
