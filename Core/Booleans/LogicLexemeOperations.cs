using Core.Contracts;
using Core.Lexemes;

namespace Core.Booleans
{
    public static class LogicLexemeOperations
    {
        public static IOperantLexeme<bool> And(IOperantLexeme<bool> left, IOperantLexeme<bool> right)
        {
            return new OperantLexeme<bool>(left.Value && right.Value);
        }

        public static IOperantLexeme<bool> Or(IOperantLexeme<bool> left, IOperantLexeme<bool> right)
        {
            return new OperantLexeme<bool>(left.Value || right.Value);
        }

        public static IOperantLexeme<bool> Mirror(IOperantLexeme<bool> value)
        {
            return new OperantLexeme<bool>(!value.Value);
        }
    }
}
