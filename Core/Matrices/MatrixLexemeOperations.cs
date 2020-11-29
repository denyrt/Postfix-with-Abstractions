using Core.Contracts;
using Core.Lexemes;

namespace Core.Matrices
{
    public static class MatrixLexemeOperations
    {
        public static IOperantLexeme<Matrix> Add(IOperantLexeme<Matrix> left, IOperantLexeme<Matrix> rigth)
        {
            return new OperantLexeme<Matrix>(Matrix.Add(left.Value, rigth.Value));
        }

        public static IOperantLexeme<Matrix> Minus(IOperantLexeme<Matrix> lexeme)
        {
            return new OperantLexeme<Matrix>(Matrix.Multiply(lexeme.Value, -1));
        }

        public static IOperantLexeme<Matrix> Multiply(IOperantLexeme<Matrix> left, IOperantLexeme<Matrix> rigth)
        {
            return new OperantLexeme<Matrix>(Matrix.Multiply(left.Value, rigth.Value));
        }

        public static IOperantLexeme<Matrix> Invariant(IOperantLexeme<Matrix> lexeme)
        {
            return new OperantLexeme<Matrix>(Matrix.InvariantMatrix(lexeme.Value));
        }
    }
}
